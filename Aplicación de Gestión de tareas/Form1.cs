using System.ComponentModel.DataAnnotations;
using System.Drawing.Text;

namespace Aplicación_de_Gestión_de_tareas
{
    public partial class Form1 : Form
    {

        private ToDoItem[] items;
        private ListBox lstItems;
        private Button btnAddItem;
        private Button btnShowPending;
        private Button btnShowComplete;

        public Form1()
        {
            InitializeComponent();

            items = new ToDoItem[]
            {
                new ToDoItem("Task 1", ItemStatus.Pending),
                new ToDoItem("Task 2", ItemStatus.Completed),
                new ToDoItem("Task 3", ItemStatus.InProgress)
            };

            lstItems = new ListBox
            {
                Location = new Point(10, 10),
                Width = 545,
                Height = 200
            };

            btnAddItem = new Button
            {
                Text = "Add Item",
                Location = new Point(10, 220),
                Size = new Size(158, 23)
            };

            btnShowPending = new Button
            {
                Text = "Show Pending",
                Location = new Point(200, 220),
                Size = new Size(158, 23)
            };

            btnShowComplete = new Button
            {
                Text = "Show Completed",
                Location = new Point(395, 220),
                Size = new Size(158, 23)
            };


            Controls.Add(lstItems);
            Controls.Add(btnAddItem);
            Controls.Add(btnShowPending);
            Controls.Add(btnShowComplete);

            btnAddItem.Click += BtnAddItem_Click;
            btnShowPending.Click += BtnShowPending_Click;
            btnShowComplete.Click += BtnShowComplete_Click;

            DisplayItems(items);
        }
        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            var newItem = new ToDoItem("New Task", ItemStatus.Pending);
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(newItem);

            bool isValid = Validator.TryValidateObject(newItem, context, validationResults, true);
            if (isValid)
            {
                Array.Resize(ref items, items.Length + 1);
                items[items.Length - 1] = newItem;
                DisplayItems(items);
            }
            else
            {
                foreach (var result in validationResults)
                {
                    if (result != null)
                    {
                        MessageBox.Show(result.ErrorMessage);
                    }
                }
            }

        }

        private void BtnShowPending_Click(object sender, EventArgs e)
        {
        var pendingItems = items.FilterByStatus(ItemStatus.Pending);
        DisplayItems(pendingItems);
        }

        private void BtnShowComplete_Click(object sender, EventArgs e)
        {
            var completedItems = items.FilterByStatus(ItemStatus.Completed);
            DisplayItems(completedItems);
        }

        private void DisplayItems (ToDoItem[] itemsToDisplay)
        {
          lstItems.Items.Clear();
          foreach (var item in itemsToDisplay)
          {
            lstItems.Items.Add(item.GetDisplayText());
          }
        }
    }
}
