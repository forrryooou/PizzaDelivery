﻿using System.Collections.Generic;

namespace PizzaDelivery.Model.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Order> Orders { get; set; }
    }
}
