using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracker.Shared.Enums
{
    public static class ShipmentEventType
    {
        public static string PURCHASE_CONFIRMED = "Purchase Confirmed";
        public static string SHIPPING_SOON = "Shipping Soon";
        public static string SHIPPED = "Shipped";
        public static string OUT_FOR_DELIVERY = "Out for delivery";
        public static string DELIVERED = "Delivered";

        public static string ParseShipmentEvent(ShipmentEventTypeEnum shipmentEventType)
        {
            return shipmentEventType switch
            {
                ShipmentEventTypeEnum.PURCHASE_CONFIRMED => PURCHASE_CONFIRMED,
                ShipmentEventTypeEnum.SHIPPING_SOON => SHIPPING_SOON,
                ShipmentEventTypeEnum.SHIPPED => SHIPPED,
                ShipmentEventTypeEnum.OUT_FOR_DELIVERY => OUT_FOR_DELIVERY,
                ShipmentEventTypeEnum.DELIVERED => DELIVERED,
                _ => throw new NotSupportedException(),
            };
        }

        public static List<string> ShipmentEvents = new()
        {
            PURCHASE_CONFIRMED,
            SHIPPING_SOON,
            SHIPPED,
            OUT_FOR_DELIVERY,
            DELIVERED
        };
    }

    public enum ShipmentEventTypeEnum
    {
        PURCHASE_CONFIRMED,
        SHIPPING_SOON,
        SHIPPED,
        OUT_FOR_DELIVERY,
        DELIVERED
    }
}
