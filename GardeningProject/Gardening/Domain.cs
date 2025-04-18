using System;

namespace Gardening
{
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
        public string TaskName { get; set; }
        public string Notes { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
