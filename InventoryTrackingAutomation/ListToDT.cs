using System;
using System.Collections.Generic;
using System.Data;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTrackingAutomation
{
    internal class ListToDT
    {
        public DataTable ListToDTConvertor(List<OrderHistory> list, ProgressBar progressBar, Label label)
        {
            DataTable DT = new DataTable();
            BindingFlags bindingFlags = BindingFlags.Public |
                            BindingFlags.NonPublic |
                            BindingFlags.Instance |
            BindingFlags.Static;
            int index = 0;
            foreach (FieldInfo field in typeof(OrderHistory).GetFields(bindingFlags))
            {
                DT.Columns.Add(field.Name);
            }
            foreach (FieldInfo field in typeof(OrderDetails).GetFields(bindingFlags))
            {
                DT.Columns.Add(field.Name);
            }
            foreach(OrderHistory orderHistory in list)
            {
                foreach(OrderDetails orderDetails in orderHistory.orderDetails)
                {
                    
                    DataRow row = DT.NewRow();
                    row["market"] = orderHistory.market;
                    row["orderNo"] = orderHistory.orderNo;
                    row["vendor"] = orderHistory.vendor;
                    row["orderDate"] = orderHistory.orderDate;
                    row["orderStatus"] = orderHistory.orderStatus;
                    row["referenceNumber"] = orderHistory.referenceNumber;
                    row["hrefLink"] = orderHistory.hrefLink;
                    row["deliveryAddress"] = orderHistory.deliveryAddress;
                    row["shippingCondition"] = orderHistory.shippingCondition;
                    row["overallStatus"] = orderHistory.overallStatus;
                    row["deliveryStatus"] = orderHistory.deliveryStatus;
                    row["items"] = orderHistory.items;
                    row["shipping"] = orderHistory.shipping;
                    row["overpack"] = orderHistory.overpack;
                    row["insurance"] = orderHistory.insurance;
                    row["taxes"] = orderHistory.taxes;
                    row["creditcardSurcharge"] = orderHistory.creditcardSurcharge;
                    row["orderTotal"] = orderHistory.orderTotal;
                    row["termsOfPayment"] = orderHistory.termsOfPayment;

                    row["item"] = orderDetails.item;
                    row["product"] = orderDetails.product;
                    row["quantity"] = orderDetails.quantity;
                    row["description"] = orderDetails.description;
                    row["totalPrice"] = orderDetails.totalPrice;
                    row["unitPrice"] = orderDetails.unitPrice;
                    row["unitPricePerDevice"] = orderDetails.unitPricePerDevice;
                    row["totalDevices"] = orderDetails.totalDevices;
                    row["status"] = orderDetails.status;
                    row["remainingQuantity"] = orderDetails.remainingQuantity;
                    DT.Rows.Add(row);
                    
                }
                progressBar.Value = index++ * 100/list.Count();
                label.Text = "Examining Data for order # " + index + " out of " + list.Count() + " orders..";

            }
            progressBar.Value = 100;
            return DT;
        }
        
    }
}
