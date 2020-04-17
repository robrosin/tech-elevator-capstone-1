using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Stock
    {
        public string Slot { get; set; }
        public string ProductName { get; set; }
        public decimal ProductCost { get; set; }
        public string ProductType { get; set; }
        public int Quantity { get; set; } = 5;
        public int AmountSold { get; set; }
        public decimal TotalSpent { get; set; }

        public Stock(string slot, string productName, decimal productCost, string productType)
        {
            Slot = slot;
            ProductName = productName;
            ProductCost = productCost;
            ProductType = productType;
            Quantity = 5;
            AmountSold = 0;
        }
    }
}