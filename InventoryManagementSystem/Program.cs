using System;

namespace InventorySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "inventory.json";

            // First session - Seed and Save
            var app = new InventoryApp(filePath);
            app.SeedSampleData();
            app.SaveData();

            // Simulate new session by creating a fresh instance
            var newApp = new InventoryApp(filePath);
            newApp.LoadData();
            newApp.PrintAllItems();
        }
    }
}
