using OrderTracker.Shared.Enums;

namespace OrderTracker.Shared.Models
{
    public class ShipmentEvent
    {
        public int Id { get; set; }
        public ShipmentEventTypeEnum EventType { get; set; }
        public string ShipmentEventName => ShipmentEventType.ParseShipmentEvent(EventType);
        public DateTime EventDate { get; set; }
        public string? FromAddress { get; set; }
        public string? ToAddress { get; set; }
    }
}
