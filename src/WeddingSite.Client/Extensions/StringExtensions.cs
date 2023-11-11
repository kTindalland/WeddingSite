namespace WeddingSite.Client.Extensions;

public static class StringExtensions
{
    private static readonly string[] SortOrder = {
        "attendance",
        "food"
    };
    
    public static int IndicatorPosition(this string section)
    {
        var order = Array.IndexOf(SortOrder, section);

        return order == -1
            ? int.MaxValue
            : order;
    }
}