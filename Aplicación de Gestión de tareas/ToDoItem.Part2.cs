public partial class ToDoItem
{
    public string GetDisplayText()
    {
        return $"{Title} - {Status}";
    }

}