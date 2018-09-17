using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Events
{
    using Adyen.EcommLibrary;
    using Adyen.EcommLibrary.Model;
    using Adyen.EcommLibrary.Service;
    using Entities;
    using Interfaces;
    using SharedKernel;

    public class RequestPaymentCompletedEvent : BaseDomainEvent
    {
        public AydenItem SettledPayment { get; set; }

        public RequestPaymentCompletedEvent(AydenItem paymentFromUser)
        {
            SettledPayment = paymentFromUser;
        }
    }
}
