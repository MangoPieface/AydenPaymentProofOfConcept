namespace CleanArchitecture.Core.Services
{
    using System.Collections.Generic;
    using Adyen.EcommLibrary;
    using Adyen.EcommLibrary.Model;
    using Adyen.EcommLibrary.Model.Enum;
    using Adyen.EcommLibrary.Service;
    using Ardalis.GuardClauses;
    using Entities;
    using Events;
    using Interfaces;
    public class AydenService : IHandle<RequestPaymentCompletedEvent>
    {
        public void Handle(RequestPaymentCompletedEvent domainCompletedEvent)
        {
            Guard.Against.Null(domainCompletedEvent, nameof(domainCompletedEvent));


        }
    }
}
