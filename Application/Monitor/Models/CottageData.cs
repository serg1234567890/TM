namespace TemperatureMonitor.Application.Monitor.Models
{
    public class CottageData
    {
        public string Id { get; set; }
        public int CottageNumber { get; set; }
        public float KitchenTemperature { get; set; }
        public float HallTemperature { get; set; }
        public float HeatingTemperature { get; set; }
    }
}
