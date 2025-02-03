using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication
{
    internal class Product
    {
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public decimal ItemPrice { get; set; }
        public int StockAmount { get; private set; }

        public Product(int prodID, string prodName, decimal itemPrice, int stockAmount)
        {
            if (prodID < 5 || prodID > 50000)
                throw new ArgumentOutOfRangeException(nameof(prodID), "Product ID must be between 5 and 50000.");
            if (itemPrice < 5 || itemPrice > 5000)
                throw new ArgumentOutOfRangeException(nameof(itemPrice), "Item price must be between $5 and $5000.");
            if (stockAmount < 5 || stockAmount > 500000)
                throw new ArgumentOutOfRangeException(nameof(stockAmount), "Stock must be between 5 and 500000.");

            ProdID = prodID;
            ProdName = prodName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
        }

        public void IncreaseStock(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Increase amount cannot be negative.");

            StockAmount += amount;
        }

        public void DecreaseStock(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Decrease amount cannot be negative.");
            if (StockAmount - amount < 0)
                throw new InvalidOperationException("Stock cannot be negative.");

            StockAmount -= amount;
        }
    }
}