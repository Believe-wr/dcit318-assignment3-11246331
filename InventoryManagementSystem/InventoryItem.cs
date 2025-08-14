using System;

namespace InventorySystem
{
    // Immutable record
    public record InventoryItem(int Id, string Name, int Quantity, DateTime DateAdded) : IInventoryEntity;
}
