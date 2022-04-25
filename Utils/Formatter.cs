using System.Globalization;

namespace RagnaBot.Utils
{
    public static class Formatter
    {
        public static string FormatUserMention(
            ulong userId
        )
        {
            return "<@" + userId.ToString(CultureInfo.InvariantCulture) + ">";
        }

        public static string FormatRoleMention(
            ulong roleId
        )
        {
            return "<@&" + roleId.ToString(CultureInfo.InvariantCulture) + ">";
        }
    }
}