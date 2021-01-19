using ShoppingListAppLibrary.Models;
using System.Collections.Generic;

namespace ShoppingListAppLibrary.Data
{
    public interface IDatabaseData
    {
        void AddItemToRecipe(string recipeName, int itemId);
        void AddItemToShoppingList(int itemId);
        void AddNewItem(string itemName, int quantity, string quantityMeasurementType, int departmentId);
        void AddRecipeItemsToShoppingList(string recipeName, int itemId);
        List<ItemModel> GetCurrentlySelectedItemsByDepartment(int department);
        List<ItemModel> GetShoppingList();
        List<DepartmentModel> GetDepartments();
        List<ItemModel> GetItemsInRecipe(string recipeName);
        List<int> GetItemIds(ItemModel model);
        void RemoveItem(ItemModel model);
        void RemoveItemFromRecipe(RecipeModel recipeModel);
        void RemoveItemFromShoppingList(int itemId);
        void UpdateItem(ItemModel model);
        void UpdateItem(ItemModel model, RecipeModel recipeModel);
        void UpdateItem(ItemModel model, ShoppingListModel shoppingListModel);
    }
}