using IITAzureWorkshop.Web.Models;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IITAzureWorkshop.Web.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(OrderDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerName = model.CustomerName,
                Email = model.Email,
                Product = model.Product.ToString(),
                Quantity = model.Quantity
            };

            // send to queue
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnection"));
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference("orders");
            queue.CreateIfNotExists();

            CloudQueueMessage message = new CloudQueueMessage(JsonConvert.SerializeObject(order));
            var timeToLive = new TimeSpan(5, 0, 0, 0);
            queue.AddMessage(message, timeToLive, null, null);

            return RedirectToAction("Index", "Home");
        }
    }
}