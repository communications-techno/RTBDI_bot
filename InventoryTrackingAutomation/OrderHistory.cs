using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTrackingAutomation
{
    internal class OrderHistory
    {
        public string orderNo = "";
        public string orderDate = "";
        public string orderStatus = "";
        public string referenceNumber = "";
        public string hrefLink = "";
        public string market = "";
        public string vendor = "";
        public string deliveryAddress = "";
        public string shippingCondition = "";

        public string overallStatus = "";
        public string deliveryStatus = "";
        public string items = "";
        public string shipping = "";
        public string overpack = "";
        public string insurance = "";
        public string taxes = "";
        public string creditcardSurcharge = "";
        public string orderTotal = "";
        public string termsOfPayment = "";

        public List<OrderDetails> orderDetails = new List<OrderDetails>();
    }

    internal class OrderDetails
    {
        public string item = "";
        public string product = "";
        public string quantity = "";
        public string description = "";
        public string totalPrice = "";
        public string unitPrice = "";
        public string totalDevices = "";
        public string unitPricePerDevice = "";
        public string status = "";
        public string remainingQuantity = "";
    }
}
