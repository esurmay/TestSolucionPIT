using FraudDetentionCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FraudDetentionCore.Interfaces
{
    public interface IFraudDetentionCore
    {
        void processFile(string filePath);

        List<Order> GetPossibleFraudOrders();

        bool IsFraudulent(List<Order> Orders);
    }
}
