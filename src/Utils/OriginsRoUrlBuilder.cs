public static class ArcadiaRoUrlBuilder
{
    public static string GetMobImageUrl(
        string mobId
    )
    {
        return $"https://cp.arcadia-online.org/data/images/monsters/{mobId}.gif";
    }

    public static string GetMobInfoUrl(
        string mobId
    )
    {
        return $"https://cp.arcadia-online.org/monster/view/?id={mobId}";
    }

    public static string GetItemImageUrl(
        int itemId
    )
    {
        return $"https://cp.arcadia-online.org/data/images/items/collection/{itemId}.png";
    }

    public static string GetItemInfoUrl(
        int itemId
    )
    {
        return $"https://cp.arcadia-online.org/item/view/?id={itemId}";
    }
}