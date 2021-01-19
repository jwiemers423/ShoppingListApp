using ShoppingListAppLibrary.Data;
using ShoppingListAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShoppingListApp.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDatabaseData db;

        public MainWindow(IDatabaseData db)
        {
            InitializeComponent();
            this.db = db;

            

            List<DepartmentModel> departments = db.GetDepartments();
            departmentSelection.ItemsSource = departments;

            List<ItemModel> shoppingList = db.GetShoppingList();
            currentShoppingList.ItemsSource = shoppingList;

        }

        private void submitNewItem_Click(object sender, RoutedEventArgs e)
        {
            // determines if the given quantity is a number.
            int QuantitySelected;
            bool quantityIntCheck = Int32.TryParse(quantity.Text, out QuantitySelected);
            
            // Check if fields are blank and if quantity is an int
            if (!String.IsNullOrEmpty(itemName.Text)
                && !String.IsNullOrEmpty(quantity.Text)
                && !String.IsNullOrEmpty(quantityType.Text)
                && !String.IsNullOrEmpty(departmentSelection.Text)
                && quantityIntCheck == true)
            {

                Object selectedItem = departmentSelection.SelectedItem;
                int departmentId = 10;
                // TODO -- Add helper class for repeating uses like update Listbox, make quantities lower case, add update button.
                bool result = Int32.TryParse(departmentSelection.SelectedValue.ToString(), out departmentId);

                // Create new model and add fields based off inputs
                var newItem = new ItemModel { 
                    ItemName = itemName.Text,
                    Quantity = QuantitySelected,
                    QuantityMeasurementType = quantityType.Text,
                    DepartmentId = departmentId };
                

                // Add Item to Items table
                db.AddNewItem(newItem.ItemName, newItem.Quantity, newItem.QuantityMeasurementType, departmentId);
                // Get Id of the newly added item
                List<int> selectedItemId = db.GetItemIds(newItem);
                // Insert item into shopping list by Id
                db.AddItemToShoppingList(selectedItemId.First());
            }

            // Delete fields for next use
            itemName.Text = null;
            quantity.Text = null;
            quantityType.Text = null;
            departmentSelection.Text = null;

            // Update Shopping List
            List<ItemModel> shoppingList = db.GetShoppingList();
            currentShoppingList.ItemsSource = shoppingList;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Select current item model
            ItemModel selectedModel = (ItemModel)currentShoppingList.SelectedItem;
            // Get Id of that model
            List<int> selectedItemId = db.GetItemIds(selectedModel);
            // Remove Item by Id from ShoppingList
            db.RemoveItemFromShoppingList(selectedItemId.First());
            // Update Shopping List
            List<ItemModel> shoppingList = db.GetShoppingList();
            currentShoppingList.ItemsSource = shoppingList;
        }

        
    }
}
