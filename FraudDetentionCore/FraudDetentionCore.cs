using FraudDetentionCore.Interfaces;
using FraudDetentionCore.Models;
using System.Net.Mail;

namespace FraudDetentionCore
{
    public class FraudDetentionCore : IFraudDetentionCore
    {

        List<Order> orders = new List<Order>();
        List<Order> FraudOrders = new List<Order>();

        public FraudDetentionCore()
        {

            
        }


        public bool IsFraudulent(List<Order> Orders)
        {

            foreach (var order in Orders)
            {
                if (order.CreditCardNumber.ToString().StartsWith("9999"))
                {
                    return false;
                }
            }
            return true;
        }


        public void processFile(string filePath)
        {
            string[] lineas = File.ReadAllLines(filePath);


            foreach (string line in lineas) 
            { 
               
                var order = MappingOrders(line);

                bool SameEmailAndDealId_DiferentCreditCard = orders.Any(x => x.EmailAddress.ToLower() == order.EmailAddress.ToLower()
                                && x.DealId == order.DealId
                                && !x.CreditCardNumber.Equals(order.CreditCardNumber));

                bool SameAddressCityStateZip_DiferentCreditCard = orders.Any(x => x.StreetAddress == order.StreetAddress
                                && x.City == order.City
                                && x.State == order.State
                                && x.ZipCode == order.ZipCode
                                && x.DealId == order.DealId
                                && !x.CreditCardNumber.Equals(order.CreditCardNumber));

                if (SameEmailAndDealId_DiferentCreditCard || SameAddressCityStateZip_DiferentCreditCard)
                {
                    FraudOrders.Add(order);
                }

                orders.Add(order);
            }

        }

        public Order MappingOrders(string line)
        {
            string[] parts = line.Split(',');


            Order order = new Order
            {
                OrderId = int.Parse(parts[0]),
                DealId = int.Parse(parts[1]),
                EmailAddress = parts[2].ToString(),
                StreetAddress = parts[3].ToString(),
                City = parts[4].ToString(),
                State = parts[5].ToString(),
                ZipCode = int.Parse(parts[6]),
                CreditCardNumber = long.Parse(parts[7])

            };

            return order;
        }

        public List<Order> GetPossibleFraudOrders()
        {

            //email y Id
           return FraudOrders;

        }
    }
}
