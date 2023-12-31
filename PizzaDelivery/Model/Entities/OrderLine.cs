﻿namespace PizzaDelivery.Model.Entities
{
    public class OrderLine
    {
        public int Id { get; set; }

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public int? OrderId { get; set; }
        public Order? Order { get; set; }

        public int Quantity { get; set; }
    }
}
