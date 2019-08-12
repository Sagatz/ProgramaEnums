using System;
using System.Collections.Generic;
using System.Text;
using ProgamaEnums.Entities.Enums;


namespace ProgamaEnums.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" ");
            sb.Append("(" + Client.BirthDate.ToString("dd/MM/yyyy") + ") - " );
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order items:");
            double total = 0;

            foreach (OrderItem p in Items)
            {
                sb.AppendLine(p.Product.Name + ", " + p.Price.ToString("F2") + ", Quantity: " + p.Quantity + ", Subtotal: $" + p.SubTotal(p.Quantity, p.Price).ToString("F2"));
                total += p.SubTotal(p.Quantity, p.Price);
            }

            sb.AppendLine("Total Price: $" + total.ToString("F2"));

            return sb.ToString();

        }

    }
}
