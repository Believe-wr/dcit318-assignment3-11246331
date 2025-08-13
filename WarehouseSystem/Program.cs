using System;
using WarehouseSystem.Services;
using WarehouseSystem.Models;
using WarehouseSystem.Exceptions;

namespace WarehouseSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WareHouseManager manager = new WareHouseManager();

            manager.SeedData();

            Console.WriteLine("\n--- Grocery Items ---");
            manager.PrintAllItems(manager.GroceriesRepo);

            Console.WriteLine("\n--- Electronic Items ---");
            manager.PrintAllItems(manager.ElectronicsRepo);

            Console.WriteLine("\n--- Testing Exceptions ---");

            try
            {
                manager.ElectronicsRepo.AddItem(new ElectronicItem(1, "Tablet", 5, "Apple", 18)); // Duplicate ID
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Caught: {ex.Message}");
            }

            try
            {
                manager.RemoveItemById(manager.ElectronicsRepo, 999); // Non-existent ID
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught: {ex.Message}");
            }

            try
            {
                manager.ElectronicsRepo.UpdateQuantity(2, -10); // Invalid quantity
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Caught: {ex.Message}");
            }

            Console.WriteLine("\n--- Final Electronic Items ---");
            manager.PrintAllItems(manager.ElectronicsRepo);

            Console.WriteLine("\n--- Final Grocery Items ---");
            manager.PrintAllItems(manager.GroceriesRepo);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
