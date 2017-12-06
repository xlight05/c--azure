using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using SendGrid.Helpers.Mail;

namespace IITAzureWorkshop.Functions
{
    public static class SendOrderConfirmation
    {
        [FunctionName("SendOrderConfirmation")]
        public static void Run(
            [QueueTrigger("orders", Connection = "AzureWebJobsStorage")] Order order,
            TraceWriter log, 
            [SendGrid(ApiKey = "SendGridApiKey")] out SendGridMessage message)
        {
            log.Info($"C# Queue trigger function processed: {order.Id}");

            message = new SendGridMessage();
            message.AddTo(order.Email);
            message.AddContent("text/html", $"Dear {order.CustomerName}, The {order.Quantity} x {order.Product}(s) you ordered is processing. Thank You for Ordering");
            message.SetFrom(new EmailAddress("noreply@k2vsoftware.com", "IIT Workshop Demo"));
            message.SetSubject("Order Completed");
        }
    }
}

public class Order
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string CustomerName { get; set; }
    public string Product { get; set; }
    public int Quantity { get; set; }
}