using System;
using System.Collections.Generic;
using Sessao9_ExercicioProposto.Entities.Enums;
using System.Text;

namespace Sessao9_ExercicioProposto.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }

        public List<OrderItem> Items = new List<OrderItem>();
        public Client Client { get; set; }

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double TotalValue = 0;            
            foreach(OrderItem thatItem1 in Items)
            {
                TotalValue += Items[Items.IndexOf(thatItem1)].SubTotal();
            }
            return TotalValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n   ---------------------------------------------------------------- ");
            sb.AppendLine("\n   ORDER SUMMARY ");
            sb.Append("\n   Order moment: " + Moment);
            sb.Append("\n   Order status: " + Status);
            sb.AppendLine("\n   Client: " + Client.Name + " (" + Client.Date + ") - " + Client.Email);
            sb.Append("\n   Order Items: ");            
            foreach (OrderItem thatItem2 in Items)
            {
                sb.Append("\n   " + Items[Items.IndexOf(thatItem2)].Product.Name + ", $" + Items[Items.IndexOf(thatItem2)].Price.ToString("F2") + ", Quantity: " + Items[Items.IndexOf(thatItem2)].Quantity + ", Subtotal: $" + Items[Items.IndexOf(thatItem2)].SubTotal().ToString("F2"));
            }

            sb.Append("\n   Total Price: $" + Total().ToString("F2"));
            sb.Append("\n\n   ---------------------------------------------------------------- ");

            return sb.ToString();
        }

    }
}
