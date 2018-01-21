using System;
using System.Linq;
using System.Text;

namespace OnkaPhilipsChannelEditor
{
    public class OnkaHelper
    {
        public static OnkaChannelName GetChannelName(string name)
        {
            OnkaChannelName channelName = new OnkaChannelName();
            try
            {
                var index = name.IndexOf(" 00x");
                if (index > 0)
                {
                    var a = name.Substring(0, index);
                    var b = name.Substring(index + 2);
                    channelName.Name = ToChar(a);
                    channelName.Suffix = ToChar(b);
                    channelName.NameLength = index;
                    channelName.SuffixLength = name.Length - index;
                }
                else
                {
                    channelName.Name = ToChar(name);
                    channelName.NameLength = name.Length;
                }
            }
            catch (Exception ex)
            {

            }
            return channelName;
        }

        static string ToChar(string name)
        {
            try
            {
                var edited = name.Replace("0x00", "").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return string.Join("", edited.Select(
                    x =>
                    {
                        return Convert.ToChar(Convert.ToUInt32(x.Replace("00x", "0x"), 16));
                    }
                    ));
            }
            catch (Exception ex)
            {

            }

            return name;
        }

        public static string SetChannelName(OnkaChannelName channelName)
        {
            var txt = SetChannelName(channelName.Name, channelName.NameLength);
            if (channelName.SuffixLength > 0)
            {
                txt += " 0" + SetChannelName(channelName.Suffix, channelName.SuffixLength);
            }
            return txt;
        }

        public static string SetChannelName(string name, int length)
        {
            if (name == null) name = "";
            
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(name);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                if (i > 0)
                    stringBuilder.Append(" ");

                var ui = (uint)name[i];
                stringBuilder.Append("0x" + ui.ToString("X") + " 0x00");                
            }
            var to = (length - stringBuilder.ToString().Length) / 5;
            for (int i = 0; i < to; i++)
            {
                stringBuilder.Append(" 0x00");
            }
            return stringBuilder.ToString();
        }
    }
}
