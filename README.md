# Azure Fundamentals Workshop 2017 - IIT

Sample code and instructions for Azure Workshop 2017 done at IIT

## Prerequisite

You need the following prerequisite in order to perform the hands-on activities during the workshop.

* **Azure Subscription _(Trial Subscription is enough)_**
* **Visual Studio Community 2017**
* **GitHub Account _(With this sample project code pushed to a repository of your own)_**

### Azure Subscription

You can create a Trial Azure Subscription to follow the hands-on demos during the workshop. Follow the instructions below to create the subscription. _You will need a Microsoft Account to proceed._

* Click the link and [Create a Microsoft Account][3] with any of your emails
* Click the link to create the [Azure Trial Subscription][2].
* Click on the **Start Free** button
* Follow the instructions and complete the details to create the Azure Subscription.

> **Note:** You will need a _Credit/Debit Card_ to complete the subscription creation process. You will not be charged. It's for identity verification.

### Visual Studio Community 2017

You need to download the [Visual Studio Community 2017][1] edition and install on your development machine to work on hands-on demo. You can sign in to Visual Studio Community 2017 instance using the _Microsoft Account_ you created in the earlier step.

### GitHub Account

Create a GitHub account and create a repository. Then push this sample code project to the new repository you just created in your own GitHub account. _We will be using it to host a web application on Azure_

## IIT Azure Workshop 2017 Sample Application

The sample application is a ASP.Net MVC Application created using the default template come with Visual Studio 2017. The solution contains 2 projects.

* **IITAzureWorkshop.Web** - _ASP.Net MVC Application_
* **IITAzureWorkshop.Functions** - _Azure Functions application_

### IITAzureWorkshop.Web

In addition to the default pages of the application. An additional **Order** page is added. This contains the UI to create a simple order that will send an email to the buyer using Azure Functions application. There are 2 **AppSettings* you need to configure to use this app.

* **AppTitle** - _Title of the application that shows up in the home page_
* **StorageConnection** - _Connection string for the Azure Storage Account. (Using this for putting the order in to the Azure Storage Queue)_ 

### IITAzureWorkshop.Functions

Azure Functions project with the pre-compiled function _SendOrderConfirmation_ which is a _Queue Triggered_ function with a _SendGrid_ output binding for sending emails using SendGrid email service.

## Sample Code for Azure Function Created using the Azure Portal

During the demo we will create an Azure Function using the Azure Portal. The sample code for that function is given bellow.

```csharp
#r "SendGrid"

using System;
using SendGrid.Helpers.Mail;

public static void Run(Order order, TraceWriter log, out Mail email)
{
    log.Info($"C# Queue trigger function processed: {order.Id}");

    var personalization = new Personalization();
    personalization.AddTo(new Email(order.Email));

    var messageContent = new Content("text/html", string.Format("Dear {0}, The {1} x {2}(s) you ordered is processing. Thank You for Ordering", order.CustomerName, order.Quantity, order.Product));

    email = new Mail();
    email.AddPersonalization(personalization);
    email.AddContent(messageContent);
    email.Subject = "Order Processing";
    email.From = new Email("info@k2vsoftware.com");
}

public class Order
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string CustomerName { get; set; }
    public string Product { get; set; }
    public int Quantity { get; set; }
}
```

[1]: https://www.visualstudio.com/downloads/
[2]: https://azure.microsoft.com/en-us/free/
[3]: https://support.microsoft.com/en-ph/help/4026324/microsoft-account-sign-up-for-a-microsoft-account