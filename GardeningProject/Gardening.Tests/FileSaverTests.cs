using System;
using System.IO;
using Xunit;
using Gardening;

namespace Gardening.Tests
{
    public class FileSaverTests
    {
        [Fact]
        public void AddPlantLog_ShouldSaveToFile()
        {
            // Arrange
            var plantLog = new PlantLog
            {
                Id = 1,
                PlantName = "Tomato",
                Observation = "Healthy",
                ActionTaken = "Watered",
                DateLogged = DateTime.Now
            };

            // Act
            FileSaver.SavePlantLogToFile(plantLog);

            // Assert
            string filePath = "plant_log.txt";
            string fileContent = File.ReadAllText(filePath);
            Assert.Contains("Tomato", fileContent);  // Ensure the plant name is in the file

            // Cleanup
            if (File.Exists(filePath))
                File.Delete(filePath);  // Clean up the file after the test
        }

        [Fact]
        public void AddInventoryItem_ShouldSaveToFile()
        {
            // Arrange
            var inventoryItem = new InventoryItem
            {
                Id = 1,
                ItemName = "Shovel",
                Quantity = 2,
                PurchaseDate = DateTime.Now,
                Notes = "Metal"
            };

            // Act
            FileSaver.SaveInventoryItemToFile(inventoryItem);

            // Assert
            string filePath = "inventory.txt";
            string fileContent = File.ReadAllText(filePath);
            Assert.Contains("Shovel", fileContent);  // Ensure the item name is in the file

            // Cleanup
            if (File.Exists(filePath))
                File.Delete(filePath);  // Clean up the file after the test
        }

        [Fact]
        public void AddPlantingLog_ShouldSaveToFile()
        {
            // Arrange
            var plantingLog = new PlantingLog
            {
                Id = 1,
                PlantName = "Tomato",
                PlantingDate = DateTime.Now,
                Notes = "Spacing: 30cm"
            };

            // Act
            FileSaver.SavePlantingLogToFile(plantingLog);

            // Assert
            string filePath = "planting_log.txt";
            string fileContent = File.ReadAllText(filePath);
            Assert.Contains("Tomato", fileContent);  // Ensure the plant name is in the file

            // Cleanup
            if (File.Exists(filePath))
                File.Delete(filePath);  // Clean up the file after the test
        }

        [Fact]
        public void AddGardeningTask_ShouldSaveToFile()
        {
            // Arrange
            var gardeningTask = new GardeningTask
            {
                Id = 1,
                TaskName = "Watering",
                ScheduledDate = DateTime.Now,
                Notes = "Tools: Hose"
            };

            // Act
            FileSaver.SaveGardeningTaskToFile(gardeningTask);

            // Assert
            string filePath = "gardening_task.txt";
            string fileContent = File.ReadAllText(filePath);
            Assert.Contains("Watering", fileContent);  // Ensure the task name is in the file

            // Cleanup
            if (File.Exists(filePath))
                File.Delete(filePath);  // Clean up the file after the test
        }
    }

    public static class FileSaver
    {
        public static void SavePlantLogToFile(PlantLog log)
        {
            string filePath = "plant_log.txt";
            string logEntry = $"{log.PlantName} | {log.Observation} | {log.ActionTaken} | {log.DateLogged}";

            File.AppendAllText(filePath, logEntry + Environment.NewLine);
        }

        public static void SaveInventoryItemToFile(InventoryItem item)
        {
            string filePath = "inventory.txt";
            string inventoryEntry = $"{item.ItemName} | {item.Quantity} | {item.PurchaseDate} | {item.Notes}";

            File.AppendAllText(filePath, inventoryEntry + Environment.NewLine);
        }

        public static void SavePlantingLogToFile(PlantingLog log)
        {
            string filePath = "planting_log.txt";
            string logEntry = $"{log.PlantName} | {log.PlantingDate} | {log.Notes}";

            File.AppendAllText(filePath, logEntry + Environment.NewLine);
        }

        public static void SaveGardeningTaskToFile(GardeningTask task)
        {
            string filePath = "gardening_task.txt";
            string taskEntry = $"{task.TaskName} | {task.ScheduledDate} | {task.Notes}";

            File.AppendAllText(filePath, taskEntry + Environment.NewLine);
        }
    }
}
