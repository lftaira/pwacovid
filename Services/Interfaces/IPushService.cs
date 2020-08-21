using System.Threading.Tasks;
using Lib.Net.Http.WebPush;
using Microsoft.AspNetCore.Mvc;

namespace CovidInfo.Services.Interfaces
{
    public interface IPushService
    {
         Task DiscardSubscriptionAsync(string endpoint);
        string GetKey();
        void SendNotificationAsync(PushMessage message);
        Task<int> StoreSubscriptionAsync([FromBody] PushSubscription subscription);
    }
}