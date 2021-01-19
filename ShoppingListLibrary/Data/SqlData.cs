using ShoppingListAppLibrary.Databases;
using ShoppingListAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingListAppLibrary.Data
{
    public class SqlData : IDatabaseData
    {
        private readonly ISqlDataAccess db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            this.db = db;
        }

        public List<ItemModel> GetCurrentlySelectedItemsByDepartment(int departmentId)
        {
            return db.LoadData<ItemModel, dynamic>("dbo.spItem_Get_Currently_Selected_Items",
                                                   new { DepartmentId = departmentId },
                                                   connectionStringName,
                                                   true);
        }
        public List<DepartmentModel> GetDepartments()
        {
            return db.LoadData<DepartmentModel, dynamic>("dbo.spGet_Departments",
                                                   new { },
                                                   connectionStringName,
                                                   true);
        }
        public List<ItemModel> GetShoppingList()
        {
            return db.LoadData<ItemModel, dynamic>("dbo.spGet_Shopping_List",
                                                           new { },
                                                           connectionStringName,
                                                           true);
        }

        public List<DepartmentModel> GetRecipes()
        {
            return db.LoadData<DepartmentModel, dynamic>("dbo.spGet_Recipes",
                                                   new { },
                                                   connectionStringName,
                                                   true);
        }

        public List<ItemModel> GetItemsInRecipe(string recipeName)
        {
            return db.LoadData<ItemModel, dynamic>("dbo.spGet_Items_Ids_In_Recipe",
                                                  new { recipeName },
                                                  connectionStringName,
                                                  true);
        }

        public List<int> GetItemIds(ItemModel model)
        {
            return db.LoadData<int, dynamic>("dbo.spGet_Item_Ids",
                                                   new { model.ItemName },
                                                   connectionStringName,
                                                   true);
        }

        public void AddNewItem(string itemName,
                                       int quantity,
                                       string quantityMeasurementType,
                                       int departmentId)
        {
            db.SaveData<dynamic>("dbo.spItems_Insert",
                                 new { itemName, quantity, quantityMeasurementType, departmentId },
                                 connectionStringName,
                                 true);
        }
        public void AddNewRecipe(string recipeName, int recipeId)
        {
            db.SaveData<dynamic>("dbo.spRecipe_Insert",
                                 new { recipeName, recipeId },
                                 connectionStringName,
                                 true);
        }

        public void AddItemToRecipe(string recipeName, int itemId)
        {
            db.SaveData<dynamic>("dbo.spAdd_Items_To_Recipe",
                                 new { recipeName, itemId },
                                 connectionStringName,
                                 true);
        }

        public void AddItemToShoppingList(int itemId)
        {
            db.SaveData<dynamic>("dbo.spAdd_Item_To_Shopping_List",
                                 new { itemId },
                                 connectionStringName,
                                 true);
        }

        public void AddRecipeItemsToShoppingList(string recipeName, int itemId)
        {
            db.SaveData<dynamic>("dbo.spAdd_Recipe_Items_To_Shopping_List",
                                               new { recipeName, itemId },
                                               connectionStringName,
                                               true);
        }

        public void UpdateItem(ItemModel model)
        {
            db.SaveData<dynamic>("dbo.spUpdate_Item",
                                 (model),
                                 connectionStringName,
                                 true);
        }
        public void UpdateItem(ItemModel model, RecipeModel recipeModel)
        {
            db.SaveData<dynamic>("dbo.spUpdate_Item_In_Recipe",
                                 (model, recipeModel),
                                 connectionStringName,
                                 true);
        }

        public void UpdateItem(ItemModel model, ShoppingListModel shoppingListModel)
        {
            db.SaveData<dynamic>("dbo.spUpdate_Item_In_ShoppingList",
                                 (model, shoppingListModel),
                                 connectionStringName,
                                 true);
        }

        public void RemoveItem(ItemModel model)
        {
            db.SaveData<dynamic>("dbo.spRemove_Item",
                                 model,
                                 connectionStringName,
                                 true);
        }

        public void RemoveRecipe(RecipeModel model)
        {
            db.SaveData<dynamic>("dbo.spRemove_Recipe",
                                 model,
                                 connectionStringName,
                                 true);
        }

        public void RemoveItemFromRecipe(RecipeModel recipeModel)
        {
            db.SaveData<dynamic>("dbo.spRemove_Item_In_Recipe",
                                 (recipeModel),
                                 connectionStringName,
                                 true);
        }

        public void RemoveItemFromShoppingList(int itemId)
        {
            db.SaveData("dbo.spRemove_Item_In_Shopping_List",
                        new { itemId = itemId },
                        connectionStringName,
                        true);
        }        
    }
}
