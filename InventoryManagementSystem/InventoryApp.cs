using System;
using System.Collections.Generic;

namespace InventorySystem
{
    public class InventoryApp
    {
        private readonly InventoryLogger<InventoryItem> _logger;

        public InventoryApp(string filePath)
        {
            _logger = new InventoryLogger<InventoryItem>(filePath);
        }

        public void SeedSampleData()
        {
            _logger.Add(new InventoryItem(1, "Laptop", 5, DateTime.Now));
            _logger.Add(new InventoryItem(2, "Mouse", 15, DateTime.Now));
            _logger.Add(new InventoryItem(3, "Keyboard", 8, DateTime.Now));
            _logger.Add(new InventoryItem(4, "Monitor", 3, DateTime.Now));
            _logger.Add(new InventoryItem(5, "Printer", 2, DateTime.Now));
        }

        public void SaveData()
        {
            _logger.SaveToFile();
        }

        public void LoadData()
        {
            _logger.LoadFromFile();
        }

        public void PrintAllItems()
        {
            List<InventoryItem> items = _logger.GetAll();

            Console.WriteLine("\n📦 Inventory Items:");
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Date Added: {item.DateAdded}");
            }
        }
    }
}
