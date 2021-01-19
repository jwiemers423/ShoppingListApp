using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingListAppLibrary
{
    public class Enums
    {
        public enum DepartmentType
        {
            Produce,
            PaperGoods,
            PastaOrCondiments,
            Dairy,
            DeliOrBread,
            DryGoodsOrCannedItems,
            Frozen,
            MeatOrSeafood,
            Pet,
            Other
        }

        public enum QuantityType
        {
            Pounds,
            Ounces, 
            Gallon,
            Quarts,
            Pints,
            Cups,
            FluidOunces,
            Tablespoon,
            Teaspoon,
            Units
        }
    }
}
