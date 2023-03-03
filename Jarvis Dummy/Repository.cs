using Dapr.Client;
using Jarvis_Dummy.Model;

namespace Jarvis_Dummy
{
    public class Repository :IRepository
    {
        const string storeName = "statestore";
       
        private readonly DaprClient _daprClient;
        public Repository( DaprClient daprClient) { _daprClient = daprClient; }

        public async Task SaveUserStateAsync(GetJarvisInfo jarvisInfo)
        {
            await _daprClient.SaveStateAsync(
                storeName, "test", jarvisInfo);
        }

        public async Task<GetJarvisInfo> GetUserStateAsync(string SingpassID)
        {
            return await _daprClient.GetStateAsync<GetJarvisInfo>(
                storeName, "test");
        }
    }
}
