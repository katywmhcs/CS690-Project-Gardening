using System;
using System.Collections.Generic;

namespace Gardening
{
    // Models
    public class PlantLog
    {
        public int Id { get; set; }
        public string PlantName { get; set; }
        public string Observation { get; set; }
        public string ActionTaken { get; set; }
        public DateTime DateLogged { get; set; }
    }

    public class InventoryItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Notes { get; set; }
    }

    public class PlantingLog
    {
        public int Id { get; set; }
        public string PlantName { get; set; }
        public DateTime PlantingDate { get; set; }
        public string Notes { get; set; }
    }

    public class GardeningTask
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public string TaskName { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Description { get; set; }
    }

    // Data Storage
    public static class DataStore
    {
        public static List<PlantLog> PlantLogs = new List<PlantLog>();
        public static List<InventoryItem> Inventory = new List<InventoryItem>();
        public static List<PlantingLog> PlantingLogs = new List<PlantingLog>();
        public static List<GardeningTask> ScheduledTasks = new List<GardeningTask>();
    }

    // Managers
    public static class PlantHealthManager
    {
        public static void AddPlantLog()
        {
            Console.WriteLine("\n--- Log Plant Health ---");
            Console.Write("Plant Name: ");
            string plantName = Console.ReadLine();

            Console.Write("Observation: ");
            string observation = Console.ReadLine();

            Console.Write("Action Taken (e.g. watering, fertilizing): ");
            string action = Console.ReadLine();

            DataStore.PlantLogs.Add(new PlantLog
            {
                Id = DataStore.PlantLogs.Count + 1,
                PlantName = plantName,
                Observation = observation,
                ActionTaken = action,
                DateLogged = DateTime.Now
            });

            Console.WriteLine("✅ Plant health logged successfully.\n");
        }

        public static void ViewLogs()
        {
            Console.WriteLine("\n--- Plant Health Logs ---");
            foreach (var log in DataStore.PlantLogs)
            {
                Console.WriteLine($"[{log.DateLogged}] {log.PlantName}: {log.Observation} (Action: {log.ActionTaken})");
            }
        }
    }

    public static class InventoryManager
    {
        public static void AddInventoryItem()
        {
            Console.WriteLine("\n--- Add Inventory Item ---");
            Console.Write("Item Name: ");
            string itemName = Console.ReadLine();

            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("Purchase Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Notes (e.g. Expiry): ");
            string notes = Console.ReadLine();

            DataStore.Inventory.Add(new InventoryItem
            {
                Id = DataStore.Inventory.Count + 1,
                ItemName = itemName,
                Quantity = quantity,
                PurchaseDate = date,
                Notes = notes
            });

            Console.WriteLine("✅ Inventory item added.\n");
        }

        public static void ViewInventory()
        {
            Console.WriteLine("\n--- Inventory List ---");
            foreach (var item in DataStore.Inventory)
            {
                Console.WriteLine($"{item.ItemName} | Qty: {item.Quantity} | Purchased: {item.PurchaseDate.ToShortDateString()} | Notes: {item.Notes}");
            }
        }
    }

public static class PlantingManager
{
    public static void AddPlantingLog()
    {
        Console.WriteLine("\n--- Log Planting Date ---");
        Console.Write("Plant Name: ");
        string plantName = Console.ReadLine();

        Console.Write("Planting Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.Write("Notes (e.g. seed type, spacing): ");
        string notes = Console.ReadLine();

        DataStore.PlantingLogs.Add(new PlantingLog
        {
            Id = DataStore.PlantingLogs.Count + 1,
            PlantName = plantName,
            PlantingDate = date,
            Notes = notes
        });

        Console.WriteLine("✅ Planting date logged.\n");
    }

    public static void ViewPlantingLogs()
    {
        Console.WriteLine("\n--- Planting Logs ---");
        foreach (var log in DataStore.PlantingLogs)
        {
            Console.WriteLine($"{log.PlantName} | Planted: {log.PlantingDate.ToShortDateString()} | Notes: {log.Notes}");
        }
    }
}

public static class GardeningTaskScheduler
{
    public static void AddScheduledTask()
    {
        Console.WriteLine("\n--- Schedule Gardening Task ---");
        Console.Write("Task Name: ");
        string taskName = Console.ReadLine();

        Console.Write("Scheduled Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.Write("Notes (e.g. tools needed): ");
        string notes = Console.ReadLine();

        DataStore.ScheduledTasks.Add(new GardeningTask
        {
            Id = DataStore.ScheduledTasks.Count + 1,
            TaskName = taskName,
            ScheduledDate = date,
            Notes = notes
        });

        Console.WriteLine("✅ Task scheduled.\n");
    }

    public static void ViewScheduledTasks()
    {
        Console.WriteLine("\n--- Scheduled Gardening Tasks ---");
        foreach (var task in DataStore.ScheduledTasks)
        {
            Console.WriteLine($"{task.TaskName} | Date: {task.ScheduledDate.ToShortDateString()} | Notes: {task.Notes}");
        }
    }
}



    // Program Entry
    public class Program
    {
        static List<PlantingLog> plantingLogs = new List<PlantingLog>();
        static List<GardeningTask> gardeningTasks = new List<GardeningTask>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n🌿 Gardening Tracker Main Menu");
                Console.WriteLine("1. Log Plant Health");
                Console.WriteLine("2. View Plant Health Logs");
                Console.WriteLine("3. Add Inventory Item");
                Console.WriteLine("4. View Inventory");
                Console.WriteLine("5. Log Planting Date");
                Console.WriteLine("6. View Planting Logs");
                Console.WriteLine("7. Schedule Gardening Task");
                Console.WriteLine("8. View Scheduled Tasks");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        PlantHealthManager.AddPlantLog();
                        break;
                    case "2":
                        PlantHealthManager.ViewLogs();
                        break;
                    case "3":
                        InventoryManager.AddInventoryItem();
                        break;
                    case "4":
                        InventoryManager.ViewInventory();
                        break;
                    case "5":
                        PlantingManager.AddPlantingLog();
                        break;
                    case "6":
                        PlantingManager.ViewPlantingLogs();
                        break;
                    case "7":
                        GardeningTaskScheduler.AddScheduledTask();
                        break;
                    case "8":
                        GardeningTaskScheduler.ViewScheduledTasks();
                        break;
                    case "9":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("❌ Invalid input. Please try again.");
                        break;
                }
            }
        }
    }
}
