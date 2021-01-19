using System;
using System.Collections.Generic;
using System.Text;
using static ShoppingListAppLibrary.Enums;

namespace ShoppingListAppLibrary.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string QuantityMeasurementType { get; set; }
        public int DepartmentId { get; set; }
    }
}
