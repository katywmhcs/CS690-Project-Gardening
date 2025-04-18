using System;
using System.Collections.Generic;

namespace Gardening
{
    public static class DataStore
    {
        public static List<PlantLog> PlantLogs = new();
        public static List<InventoryItem> Inventory = new();
        public static List<PlantingLog> PlantingLogs = new();
        public static List<GardeningTask> ScheduledTasks = new();
    }

    public static class PlantHealthManager
    {
        public static void AddPlantLog(string plantName, string observation, string action)
        {
            DataStore.PlantLogs.Add(new PlantLog
            {
                Id = DataStore.PlantLogs.Count + 1,
                PlantName = plantName,
                Observation = observation,
                ActionTaken = action,
                DateLogged = DateTime.Now
            });
        }

        public static List<PlantLog> GetLogs() => DataStore.PlantLogs;
    }

    public static class InventoryManager
    {
        public static void AddInventoryItem(string itemName, int quantity, DateTime date, string notes)
        {
            DataStore.Inventory.Add(new InventoryItem
            {
                Id = DataStore.Inventory.Count + 1,
                ItemName = itemName,
                Quantity = quantity,
                PurchaseDate = date,
                Notes = notes
            });
        }

        public static List<InventoryItem> GetInventory() => DataStore.Inventory;
    }

    public static class PlantingManager
    {
        public static void AddPlantingLog(string plantName, DateTime date, string notes)
        {
            DataStore.PlantingLogs.Add(new PlantingLog
            {
                Id = DataStore.PlantingLogs.Count + 1,
                PlantName = plantName,
                PlantingDate = date,
                Notes = notes
            });
        }

        public static List<PlantingLog> GetLogs() => DataStore.PlantingLogs;
    }

    public static class TaskManager
    {
        public static void AddTask(string name, DateTime date, string notes)
        {
            DataStore.ScheduledTasks.Add(new GardeningTask
            {
                Id = DataStore.ScheduledTasks.Count + 1,
                TaskName = name,
                ScheduledDate = date,
                Notes = notes
            });
        }

        public static List<GardeningTask> GetTasks() => DataStore.ScheduledTasks;
    }
}
