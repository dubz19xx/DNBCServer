using System.Text;

namespace DBServer.Helper
{
    public class DNHelpers
    {
        private static readonly string _alphanumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GenerateRandomString(int length)
        {
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                // Pick a random character from _alphanumericChars
                char randomChar = _alphanumericChars[random.Next(_alphanumericChars.Length)];
                stringBuilder.Append(randomChar);
            }

            return stringBuilder.ToString();
        }


    }
}
