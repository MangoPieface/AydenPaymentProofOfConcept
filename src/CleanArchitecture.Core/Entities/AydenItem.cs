using CleanArchitecture.Core.Events;
using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Core.Entities
{
    using System.Collections.Generic;
    using Adyen.EcommLibrary;
    using Adyen.EcommLibrary.Model;
    using Adyen.EcommLibrary.Service;

    public class AydenItem : BaseEntity
    {
        public string EncryptedPersonalAndPaymentData { get; set; } 
        public long? Amount { get; set; }
        public string Currency { get; set; }
        
        //fulfilment details
        public string AuthCode { get; set; }
        public string ResultCode { get; set; }
        public string PspReference { get; set; }


        public void RequestPaymentFulfilment()
        {
            //API
            var client = new Client("ws@Company.ExampleCompany", "password", Adyen.EcommLibrary.Model.Enum.Environment.Test,
                "ExampleCompanyCOM");

            var payment = new Payment(client);

            var paymentRequest = new PaymentRequest
            {
                Amount = new Amount(Currency, Amount),
                AdditionalData = new Dictionary<string, string>
                {
                    {"card.encrypted.json", EncryptedPersonalAndPaymentData}
                },
                Reference = "Merchant reference",
                MerchantAccount = "ExampleCompanyCOM"
            };

            var paymentResult =  payment.Authorise(paymentRequest);

            ResultCode = paymentResult.ResultCode.ToString();
            PspReference = paymentResult.PspReference;
            AuthCode = paymentResult.AuthCode;

            Events.Add(new RequestPaymentCompletedEvent(this));
        }
    }
}