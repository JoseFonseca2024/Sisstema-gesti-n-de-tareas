using System.ComponentModel.DataAnnotations;

public partial class ToDoItem
{
    [Required(ErrorMessage = "El Titulo es obligatorio")]
    [StringLength(100, ErrorMessage = "El titulo no puede tener mas de 100 caracteres")]
    public string Title { get; set; }

    [EnumDataType(typeof(ItemStatus), ErrorMessage = "El estado debe de ser valido")]

    public ItemStatus Status { get; set; }

    public ToDoItem(string title, ItemStatus status )
    {
        Title = title;
        Status = status;
    }
}
