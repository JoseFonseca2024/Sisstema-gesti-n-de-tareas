public static class AppSettings
{
    public static string AplicactionName { get; set; } = "To-Do Manager";
    public static string DefaultItemStatus { get; set; } = "Pending";
}

public static class ToDoUtilities
{
    public static int CountItemsByStatus(ToDoItem[] items, ItemStatus status)
    {
        int count = 0;
        foreach (var item in items)
        {
            if (item.Status == status)
            {
                count++;
            }
        }
        return count;
    }
}