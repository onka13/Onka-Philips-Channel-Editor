using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace OnkaPhilipsChannelEditor
{
    public partial class FormMain : Form
    {
        string originalXmlData = "";
        ChannelMap root;
        string _lang = "en";
        ResourceManager resourceManager;

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(string lang)
        {
            this._lang = lang;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.AllowDrop = true;
            splitContainer1.Enabled = false;
            resourceManager = new ResourceManager(typeof(FormMain));

            if (_lang == "tr-TR") cLanguageTurkish.Checked = true;
            else cLanguageEnglish.Checked = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            originalXmlData = File.ReadAllText(openFileDialog.FileName);

            var serializer = new XmlSerializer(typeof(ChannelMap));
            serializer.UnknownAttribute += (sender2, e2) =>
            {
                var a = e2.Attr;
            };
            serializer.UnreferencedObject += (sender2, e2) =>
            {
                var a = e2.UnreferencedObject;
            };
            serializer.UnknownElement += (sender2, e2) =>
            {
                var a = e2.Element;
            };

            XmlReaderSettings settings = new XmlReaderSettings
            {
                CheckCharacters = false,
            };

            using (var stream = new StringReader(originalXmlData))
            using (var reader = XmlReader.Create(stream, settings))
            {
                root = (ChannelMap)serializer.Deserialize(reader);
            }

            listBox1.DataSource = root.Channel;
            splitContainer1.Enabled = true;
            cStatus.Text = openFileDialog.FileName;



            Log(resourceManager.GetString("form_open_file") + " => " + openFileDialog.FileName);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                txtNo.Text = "";
                txtName.Text = "";
                return;
            }

            var channel = listBox1.SelectedItem as ChannelMapChannel;
            txtNo.Text = channel.Setup.ChannelNumber.ToString();
            txtFavoriteNo.Text = channel.Setup.FavoriteNumber.ToString();
            var cName = OnkaHelper.GetChannelName(channel.Setup.ChannelName);
            txtName.Text = cName.Name;
            lblChannelSuffix.Text = cName.Suffix;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            var channel = listBox1.SelectedItem as ChannelMapChannel;

            var newNo = Convert.ToUInt16(txtNo.Text);
            if (channel.Setup.ChannelNumber != newNo)
            {
                var otherChannel = root.Channel.FirstOrDefault(x => x.Setup.ChannelNumber == newNo);
                if (otherChannel != null)
                {
                    Log(otherChannel.Setup._niceChannelName + " " + otherChannel.Setup.ChannelNumber + " => " + channel.Setup.ChannelNumber);

                    otherChannel.Setup.ChannelNumber = channel.Setup.ChannelNumber;
                }
            }
            Log(channel.Setup._niceChannelName + " " + channel.Setup.ChannelNumber + " => " + newNo + ", " + txtName.Text);

            channel.Setup.ChannelNumber = newNo;
            channel.Setup.FavoriteNumber = Convert.ToInt32(txtFavoriteNo.Text);
            var cName = OnkaHelper.GetChannelName(channel.Setup.ChannelName);
            cName.Name = txtName.Text;
            channel.Setup.ChannelName = OnkaHelper.SetChannelName(cName);

            ReBindList(listBox1.SelectedIndex, channel);

            if (cAutoSort.Checked) SortByNo();
        }

        private void sortByNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortByNo();
            Log(resourceManager.GetString("sortByNoToolStripMenuItem.Text"));
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (root == null || root.Channel == null || root.Channel.Length == 0) return;

            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var serializer = new XmlSerializer(typeof(ChannelMap), GetXmlAttributeOverrides());

            XmlWriterSettings settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true,
                IndentChars = "\t",
                NewLineHandling = NewLineHandling.None,
                CheckCharacters = false,
            };

            StringBuilder builder = new StringBuilder();
            using (var stream = new StringWriter(builder))
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, root);
                var output = builder.ToString();
                if (!output.StartsWith("<?xml"))
                {
                    output = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n" + output;
                }
                File.WriteAllText(dialog.FileName, output);
            }
            Log(resourceManager.GetString("form_save_file") + " => " + dialog.FileName);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = root.Channel.Where(x => x.Setup._niceChannelName.Name.ToLowerInvariant().Contains(txtSearch.Text.ToLowerInvariant())).ToList();
        }

        private void orderAllReNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var index = listBox1.SelectedIndex;
            root.Channel = root.Channel.OrderBy(x => x.Setup.ChannelNumber).ToArray();
            for (int i = 0; i < root.Channel.Length; i++)
            {
                root.Channel[i].Setup.ChannelNumber = Convert.ToUInt16(i + 1);
            }
            ReBindList(index);

            Log(resourceManager.GetString("orderAllReNumberToolStripMenuItem.Text"));
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            /*listBox1_SelectedIndexChanged(null, null);
            if (listBox1.SelectedItem == null) return;
            listBox1.DoDragDrop(listBox1.SelectedItem, DragDropEffects.Move);*/
        }

        private void listBox1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            Point point = listBox1.PointToClient(new Point(e.X, e.Y));
            int index = listBox1.IndexFromPoint(point);
            if (index < 0) index = listBox1.Items.Count - 1;
            ChannelMapChannel data = (ChannelMapChannel)e.Data.GetData(typeof(ChannelMapChannel));
            data.Setup.ChannelNumber = Convert.ToUInt16(index + 1);
            var channels = root.Channel.ToList();
            channels.Remove(data);
            channels.Insert(index, data);
            root.Channel = channels.ToArray();

            ReBindList(index);
        }

        private void favoriteFirst255ChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var index = listBox1.SelectedIndex;
            for (int i = 0; i < root.Channel.Length; i++)
            {
                if (i < 254)
                {
                    root.Channel[i].Setup.FavoriteNumber = Convert.ToInt32(i + 1);
                }
                else
                {
                    root.Channel[i].Setup.FavoriteNumber = 0;
                }
            }
            ReBindList(index);
            MessageBox.Show("Ok");
        }

        private void orderBySavedFileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                string data = File.ReadAllText(openFileDialog.FileName);

                var serializer = new XmlSerializer(typeof(ChannelMap));

                using (var stream = new StringReader(data))
                using (var reader = XmlReader.Create(stream))
                {
                    var otherFile = (ChannelMap)serializer.Deserialize(reader);
                    for (int i = 0; i < otherFile.Channel.Length; i++)
                    {
                        for (int j = 0; j < root.Channel.Length; j++)
                        {
                            try
                            {
                                if (root.Channel[j].Setup._niceChannelName.Name == otherFile.Channel[i].Setup._niceChannelName.Name)
                                {
                                    root.Channel[j].Setup.ChannelNumber = otherFile.Channel[i].Setup.ChannelNumber;
                                    break;
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }                
                Log(resourceManager.GetString("orderBySavedFileListToolStripMenuItem.Text") + " => " + openFileDialog.FileName);
                orderAllReNumberToolStripMenuItem_Click(null, null);
            }
            catch (Exception ex)
            {
                Log("Error: " + ex.Message);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormAboutBox().ShowDialog();
        }

        private void btnDeleteChannel_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            var index = listBox1.SelectedIndex;
            var name = root.Channel[index].Setup._niceChannelName;

            var list = root.Channel.ToList();
            list.RemoveAt(index);
            root.Channel = list.ToArray();

            ReBindList(index - 1);

            Log(name + " " + resourceManager.GetString("form_deleted"));
        }

        void SortByNo()
        {
            root.Channel = root.Channel.OrderBy(x => x.Setup.ChannelNumber).ToArray();
            ReBindList(listBox1.SelectedIndex, listBox1.SelectedItem);
        }

        void ReBindList(int index = 0, object item = null)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = root.Channel;

            if (item != null) listBox1.SelectedItem = item;
            else if (index > 0) listBox1.SelectedIndex = index;
        }

        void Log(string msg)
        {
            txtLog.Text = txtLog.Text.Insert(0, DateTime.Now.ToString("HH:mm:ss") + ":" + msg + "\n");
            txtLog.SelectionStart = 0;
            txtLog.SelectionLength = 0;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            if (listBox1.SelectedIndex == 0) return;
            var channel = listBox1.SelectedItem as ChannelMapChannel;

            var nextIndex = listBox1.SelectedIndex - 1;

            var nextItemNo = root.Channel[nextIndex].Setup.ChannelNumber;

            Log(channel.Setup._niceChannelName + " " + channel.Setup.ChannelNumber + " -> " + nextItemNo);

            root.Channel[nextIndex].Setup.ChannelNumber = channel.Setup.ChannelNumber;
            if (channel.Setup.ChannelNumber == nextItemNo) nextItemNo--;
            channel.Setup.ChannelNumber = nextItemNo;

            ReBindList(listBox1.SelectedIndex, channel);

            SortByNo();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            if (listBox1.SelectedIndex == listBox1.Items.Count - 1) return;
            var channel = listBox1.SelectedItem as ChannelMapChannel;

            var nextIndex = listBox1.SelectedIndex + 1;

            var nextItemNo = root.Channel[nextIndex].Setup.ChannelNumber;
            root.Channel[nextIndex].Setup.ChannelNumber = channel.Setup.ChannelNumber;
            if (channel.Setup.ChannelNumber == nextItemNo) nextItemNo++;
            channel.Setup.ChannelNumber = nextItemNo;

            Log(channel.Setup._niceChannelName + " " + channel.Setup.ChannelNumber + " -> " + nextItemNo);

            ReBindList(listBox1.SelectedIndex, channel);

            SortByNo();
        }

        private void cLanguageEnglish_Click(object sender, EventArgs e)
        {
            ChangeLang("en");
        }

        private void cLanguageTurkish_Click(object sender, EventArgs e)
        {
            ChangeLang("tr-TR");
        }
        void ChangeLang(string lang)
        {
            if (_lang == lang) return;
            Thread t = new Thread(new ThreadStart(() =>
            {
                Application.Run(new FormMain(lang));
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            this.Close();
        }

        private void btn10Up_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            if (listBox1.SelectedIndex == 0) return;
            var channel = listBox1.SelectedItem as ChannelMapChannel;
            var channelNo = channel.Setup.ChannelNumber;

            var nextIndex = Math.Max(listBox1.SelectedIndex - 10, 0);

            var nextItemNo = root.Channel[nextIndex].Setup.ChannelNumber;

            Log(channel.Setup._niceChannelName + " " + channel.Setup.ChannelNumber + " -> " + nextItemNo);
            channel.Setup.ChannelNumber = nextItemNo;

            for (int i = listBox1.SelectedIndex - 1; i >= nextIndex; i--)
            {
                var no = root.Channel[i].Setup.ChannelNumber;
                root.Channel[i].Setup.ChannelNumber = channelNo;
                channelNo = no;
            }

            ReBindList(nextIndex, channel);

            SortByNo();
        }

        private void btn10Down_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            if (listBox1.SelectedIndex == listBox1.Items.Count - 1) return;
            var channel = listBox1.SelectedItem as ChannelMapChannel;
            var channelNo = channel.Setup.ChannelNumber;

            var nextIndex = Math.Min(listBox1.SelectedIndex + 10, listBox1.Items.Count - 1);

            var nextItemNo = root.Channel[nextIndex].Setup.ChannelNumber;

            Log(channel.Setup._niceChannelName + " " + channel.Setup.ChannelNumber + " -> " + nextItemNo);
            channel.Setup.ChannelNumber = nextItemNo;

            for (int i = listBox1.SelectedIndex + 1; i <= nextIndex; i++)
            {
                var no = root.Channel[i].Setup.ChannelNumber;
                root.Channel[i].Setup.ChannelNumber = channelNo;
                channelNo = no;
            }

            ReBindList(nextIndex, channel);

            SortByNo();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        XmlAttributeOverrides GetXmlAttributeOverrides()
        {
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();

            // ChannelMapChannelSetup
            var setupList = new List<string> { "SatelliteName", "Scramble" };
            foreach (var setupProp in setupList)
            {
                if (!originalXmlData.Contains(setupProp + "="))
                {
                    XmlAttributes attribs = new XmlAttributes();
                    attribs.XmlIgnore = true;
                    attribs.XmlElements.Add(new XmlElementAttribute(setupProp));
                    overrides.Add(typeof(ChannelMapChannelSetup), setupProp, attribs);
                }
            }

            // ChannelMapChannelBroadcast
            var broadcastList = new List<string> { "Bandwidth", "DecoderType", "SubType", "NetworkID", "StreamPriority", "UniqueID", "LNBNumber", "Polarization" };
            foreach (var broadProp in broadcastList)
            {
                if (!originalXmlData.Contains(broadProp + "="))
                {
                    XmlAttributes attribs = new XmlAttributes();
                    attribs.XmlIgnore = true;
                    attribs.XmlElements.Add(new XmlElementAttribute(broadProp));
                    overrides.Add(typeof(ChannelMapChannelBroadcast), broadProp, attribs);
                }
            }

            return overrides;
        }
    }
}
