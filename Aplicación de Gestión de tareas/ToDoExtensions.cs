public static class ToDoItemExtensions
{
    public static ToDoItem[] FilterByStatus(this ToDoItem[] items, ItemStatus status)
    {
        int count = ToDoUtilities.CountItemsByStatus(items, status);
        var result = new ToDoItem[count];
        int index = 0;

        foreach (var item in items)
        {
            if (item.Status == status)
            {
                result[index++] = item;
            }
        }
        return result;
    } 
}