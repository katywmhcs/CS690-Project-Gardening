using System;
using System.IO;
using Xunit;
using Gardening;
using System.Collections.Generic;

public class DataManagerSaveTests
{
    private const string InventoryLogFile = "test_inventory.txt";

    [Fact]
    public void SaveInventoryToFile_AppendsInventoryEntries()
    {
        // Arrange
        if (File.Exists(InventoryLogFile))
            File.Delete(InventoryLogFile);

        var fileSaver = new FileSaver(InventoryLogFile);

        DataStore.Inventory = new List<InventoryItem>
        {
            new InventoryItem { Id = 1, ItemName = "Fertilizer", Quantity = 2, PurchaseDate = DateTime.Today, Notes = "Organic" },
            new InventoryItem { Id = 2, ItemName = "Seeds", Quantity = 10, PurchaseDate = DateTime.Today, Notes = "Tomato" }
        };

        // Act
        foreach (var item in DataStore.Inventory)
        {
            string line = $"{item.ItemName},{item.Quantity},{item.PurchaseDate.ToShortDateString()},{item.Notes}";
            fileSaver.AppendLine(line);
        }

        // Assert
        var contents = File.ReadAllText(InventoryLogFile);
        Assert.Contains("Fertilizer", contents);
        Assert.Contains("Seeds", contents);
    }

    // Cleanup
    ~DataManagerSaveTests()
    {
        if (File.Exists(InventoryLogFile))
            File.Delete(InventoryLogFile);
    }
}
