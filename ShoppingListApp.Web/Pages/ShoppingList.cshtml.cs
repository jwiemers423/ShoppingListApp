using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingListAppLibrary.Data;
using ShoppingListAppLibrary.Models;

namespace ShoppingListApp.Web.Pages
{
    public class ShoppingListModel : PageModel
    {
        private readonly IDatabaseData db;
        public List<SelectListItem> Departments { get; set; } = new List<SelectListItem>();
        public List<ItemModel> Items { get; set; } = new List<ItemModel>();

        

        [BindProperty]
        public DepartmentModel Department { get; set; } = new DepartmentModel();
        private int SelectedDepartmentId = 1;

        [BindProperty(SupportsGet = true)]
        public Boolean IsChecked { get; set; }

        public List<ItemModel> previousModels { get; set; } = new List <ItemModel>();        


        public ShoppingListModel(IDatabaseData db)
        {
            this.db = db;
        }
        public void OnGet()
        {
            GetItemsList();
        }

        public void OnPost()
        {
            SelectedDepartmentId = Department.Id;
            GetItemsList();
            
        }

        public void GetItemsList()
        {
            {      

                var departments = db.GetDepartments();

                departments.ForEach(x =>
                {
                    Departments.Add(new SelectListItem { Value = x.Id.ToString(), Text = x.DepartmentName });
                });

                var itemsPerDepartment = db.GetCurrentlySelectedItemsByDepartment(SelectedDepartmentId);

                itemsPerDepartment.ForEach(x =>
                {
                    ItemModel newModel = new ItemModel { ItemName = x.ItemName, Quantity = x.Quantity, QuantityMeasurementType = x.QuantityMeasurementType, DepartmentId = x.DepartmentId };
                    
                    previousModels.Add(newModel);                   
                    Items.Add( newModel);                    
                });
            }
        }

        


        
    }
}
