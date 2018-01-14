using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace OnkaPhilipsChannelEditor
{
    public partial class FormMain : Form
    {
        ChannelMap root;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.AllowDrop = true;
            splitContainer1.Enabled = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string data = File.ReadAllText(openFileDialog.FileName);

            var serializer = new XmlSerializer(typeof(ChannelMap));

            XmlReaderSettings settings = new XmlReaderSettings
            {
                CheckCharacters = false,
            };

            using (var stream = new StringReader(data))
            using (var reader = XmlReader.Create(stream, settings))
            {
                root = (ChannelMap)serializer.Deserialize(reader);
            }

            listBox1.DataSource = root.Channel;
            splitContainer1.Enabled = true;
            cStatus.Text = openFileDialog.FileName;

            Log("Opened from " + openFileDialog.FileName);
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
            txtName.Text = OnkaHelper.GetChannelName(channel.Setup.ChannelName);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            var channel = listBox1.SelectedItem as ChannelMapChannel;

            var newNo = Convert.ToUInt16(txtNo.Text);
            if (channel.Setup.ChannelNumber != newNo)
            {
                var otherChannel = root.Channel.FirstOrDefault(x => x.Setup.ChannelNumber == newNo);
                if(otherChannel != null)
                {
                    Log(otherChannel.Setup._niceChannelName + " " + otherChannel.Setup.ChannelNumber + " changed to " + channel.Setup.ChannelNumber);

                    otherChannel.Setup.ChannelNumber = channel.Setup.ChannelNumber;
                }                
            }
            Log(channel.Setup._niceChannelName + " " + channel.Setup.ChannelNumber + " changed to " + newNo);

            channel.Setup.ChannelNumber = newNo;
            channel.Setup.FavoriteNumber = Convert.ToByte(txtFavoriteNo.Text);
            channel.Setup.ChannelName = OnkaHelper.SetChannelName(txtName.Text);

            ReBindList(listBox1.SelectedIndex, channel);

            if (cAutoSort.Checked) SortByNo();
        }

        private void sortByNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortByNo();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var serializer = new XmlSerializer(typeof(ChannelMap));

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
            Log("Saved to " + dialog.FileName);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = root.Channel.Where(x => x.Setup._niceChannelName.Contains(txtSearch.Text)).ToList();
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

            Log("Order All - Re Number");
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
                    root.Channel[i].Setup.FavoriteNumber = Convert.ToByte(i + 1);
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
                            if (root.Channel[j].Setup._niceChannelName == otherFile.Channel[i].Setup._niceChannelName)
                            {
                                root.Channel[j].Setup.ChannelNumber = otherFile.Channel[i].Setup.ChannelNumber;
                                break;
                            }
                        }
                    }
                }
                Log("Order by saved file list " + openFileDialog.FileName);
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

            Log(name + " deleted");
        }

        void SortByNo()
        {
            root.Channel = root.Channel.OrderBy(x => x.Setup.ChannelNumber).ToArray();
            ReBindList(listBox1.SelectedIndex, listBox1.SelectedItem);
            Log("Sorted by no");
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

            Log(channel.Setup._niceChannelName + " -> " + nextItemNo);

            ReBindList(listBox1.SelectedIndex, channel);

            SortByNo();
        }
    }
}
