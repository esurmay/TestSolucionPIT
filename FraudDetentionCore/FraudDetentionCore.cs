using FraudDetentionCore.Interfaces;
using FraudDetentionCore.Models;

namespace FraudDetentionCore
{
    public class FraudDetentionCore: IFraudDetentionCore
    {

        public FraudDetentionCore()
        {
                
        }


        public bool IsFraudulent(List<Orders> Orders) 
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




    }
}
