using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FraudDetentionCore.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int DealId { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public string StreetAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int ZipCode { get; set; }
        public int CreditCardNumber { get; set; }
    }
}
