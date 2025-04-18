using System;

namespace Gardening
{
    public static class ConsoleUI
    {
        public static void ShowMainMenu()
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
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        LogPlantHealth();
                        break;
                    case "2":
                        ViewPlantHealthLogs();
                        break;
                    case "3":
                        AddInventoryItem();
                        break;
                    case "4":
                        ViewInventory();
                        break;
                    case "5":
                        LogPlantingDate();
                        break;
                    case "6":
                        ViewPlantingLogs();
                        break;
                    case "7":
                        ScheduleTask();
                        break;
                    case "8":
                        ViewScheduledTasks();
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

        private static void LogPlantHealth()
        {
            Console.Write("Plant Name: ");
            string name = Console.ReadLine();
            Console.Write("Observation: ");
            string obs = Console.ReadLine();
            Console.Write("Action Taken: ");
            string action = Console.ReadLine();

            PlantHealthManager.AddPlantLog(name, obs, action);
            Console.WriteLine("✅ Plant health logged.\n");
        }

        private static void ViewPlantHealthLogs()
        {
            foreach (var log in PlantHealthManager.GetLogs())
            {
                Console.WriteLine($"[{log.DateLogged}] {log.PlantName}: {log.Observation} (Action: {log.ActionTaken})");
            }
        }

        private static void AddInventoryItem()
        {
            Console.Write("Item Name: ");
            string item = Console.ReadLine();
            Console.Write("Quantity: ");
            int qty = int.Parse(Console.ReadLine());
            Console.Write("Purchase Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Notes: ");
            string notes = Console.ReadLine();

            InventoryManager.AddInventoryItem(item, qty, date, notes);
            Console.WriteLine("✅ Inventory item added.\n");
        }

        private static void ViewInventory()
        {
            foreach (var item in InventoryManager.GetInventory())
            {
                Console.WriteLine($"{item.ItemName} | Qty: {item.Quantity} | Purchased: {item.PurchaseDate.ToShortDateString()} | Notes: {item.Notes}");
            }
        }

        private static void LogPlantingDate()
        {
            Console.Write("Plant Name: ");
            string name = Console.ReadLine();
            Console.Write("Planting Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Notes: ");
            string notes = Console.ReadLine();

            PlantingManager.AddPlantingLog(name, date, notes);
            Console.WriteLine("✅ Planting date logged.\n");
        }

        private static void ViewPlantingLogs()
        {
            foreach (var log in PlantingManager.GetLogs())
            {
                Console.WriteLine($"{log.PlantName} | Planted: {log.PlantingDate.ToShortDateString()} | Notes: {log.Notes}");
            }
        }

        private static void ScheduleTask()
        {
            Console.Write("Task Name: ");
            string name = Console.ReadLine();
            Console.Write("Scheduled Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Notes: ");
            string notes = Console.ReadLine();

            TaskManager.AddTask(name, date, notes);
            Console.WriteLine("✅ Task scheduled.\n");
        }

        private static void ViewScheduledTasks()
        {
            foreach (var task in TaskManager.GetTasks())
            {
                Console.WriteLine($"{task.TaskName} | Date: {task.ScheduledDate.ToShortDateString()} | Notes: {task.Notes}");
            }
        }
    }
}
