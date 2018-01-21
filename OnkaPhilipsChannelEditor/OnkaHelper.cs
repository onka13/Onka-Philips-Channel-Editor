using System;
using System.Linq;
using System.Text;

namespace OnkaPhilipsChannelEditor
{
    public class OnkaHelper
    {
        public static string GetChannelName(string name)
        {
            try
            {
                var edited = name.Replace("0x00", "").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return string.Join("", edited.Select(
                    x => Convert.ToChar(Convert.ToUInt32(x, 16))
                    ));
            }
            catch (Exception ex)
            {
                return name;
            }
        }

        public static string SetChannelName(string name)
        {
            if (name == null) name = "";
            if (name.Length > 24)
                name = name.Substring(0, 24);
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(name);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                var ui = (uint)name[i];
                stringBuilder.Append("0x" + ui.ToString("X") + " ");
                stringBuilder.Append("0x00 ");
            }
            var to = 50 - (name.Length * 2) - 1;
            for (int i = 0; i < to; i++)
            {
                stringBuilder.Append("0x00 ");
            }
            stringBuilder.Append("0x00");
            return stringBuilder.ToString();
        }
    }
}
