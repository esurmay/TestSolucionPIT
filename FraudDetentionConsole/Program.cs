using FraudDetentionCore.Interfaces;
using FraudDetentionCore;
using Microsoft.Extensions.DependencyInjection; // Add this if your implementation is in this namespace

var serviceProvider = new ServiceCollection()
                .AddSingleton<IFraudDetentionCore, FraudDetentionCore.FraudDetentionCore>();


var fraudDetentionCoreService = serviceProvider.BuildServiceProvider().GetService<IFraudDetentionCore>();


string filePath = Path.Combine(AppContext.BaseDirectory, "orders.txt");

fraudDetentionCoreService.processFile(filePath);

var OrderedList = fraudDetentionCoreService.GetPossibleFraudOrders().OrderBy(o => o.DealId).ToList();

 Console.WriteLine("Posibles Ordenes Fraudulentas:");
int count = 1;
foreach (var item in OrderedList)
{
    Console.WriteLine($"Item: {count}: OrderId: {item.OrderId}, DealId: {item.DealId}, EmailAddress: {item.EmailAddress}, StreetAddress: {item.StreetAddress}, City: {item.City}, State: {item.State}, ZipCode: {item.ZipCode}, CreditCardNumber: {item.CreditCardNumber}");
    count++;
}
