using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {
        public Dictionary<string, Stock> Inventory { get; set; }
        public decimal Balance { get; set; }
        public string Report { get; private set; }
        //public int ChangeReturn { get; set; }

        public VendingMachine(string path)
        {
            Inventory = new Dictionary<string, Stock>();
            using (StreamReader rdr = new StreamReader(path))
            {
                string[] productDetail;
                string line = "";
                while (!rdr.EndOfStream)
                {
                    line = rdr.ReadLine();
                    productDetail = line.Split("|");
                    Stock stock = new Stock(productDetail[0], productDetail[1], decimal.Parse(productDetail[2]), productDetail[3]);
                    Inventory.Add(stock.Slot, stock);
                }

            }
        }
        public void FeedMoney(decimal added)
        {
            this.Balance += added;
            return;
        }
        public void DisplayProduct()
        {
            foreach (KeyValuePair<string, Stock> inventory in Inventory)
            {
                Console.WriteLine($"{inventory}");
            }
        }
        public void ChangeReturn(decimal tempamount)
        {
            int changeQuarters = 0;
            int changeDimes = 0;
            int changeNickels = 0;
            decimal tempAmount = this.Balance * 100;

            while (tempAmount >= 0)
            {
                if (tempAmount >= 25)
                {
                    changeQuarters++;
                    tempAmount = tempAmount - 25;
                }
                else if (tempAmount >= 10)
                {
                    changeDimes++;
                    tempAmount = tempAmount - 10;
                }
                else if (tempAmount >= 5)
                {
                    changeNickels++;
                    tempAmount = tempAmount - 5;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
