using System.Collections.Generic;

namespace lab8.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Order> Orders { get; set; }
    }
}
