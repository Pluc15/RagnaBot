namespace RagnaBot.Utils
{
    public static class OriginsRoUrlBuilder
    {
        public static string GetMobImageUrl(
            string mobId
        )
        {
            return $"https://cp.originsro.org/data/images/monsters/{mobId}.gif";
        }
        
        public static string GetMobInfoUrl(
            string mobId
        )
        {
            return $"https://cp.originsro.org/monster/view/?id={mobId}";
        }
        
        public static string GetItemImageUrl(
            int itemId
        )
        {
            return $"https://cp.originsro.org/data/images/items/collection/{itemId}.png";
        }
        
        public static string GetItemInfoUrl(
            int itemId
        )
        {
            return $"https://cp.originsro.org/item/view/?id={itemId}";
        }
    }
}