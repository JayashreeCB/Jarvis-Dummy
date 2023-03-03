using Jarvis_Dummy.Model;

namespace Jarvis_Dummy
{
    public interface IRepository
    {
         Task SaveUserStateAsync(GetJarvisInfo jarvisInfo);
         Task<GetJarvisInfo> GetUserStateAsync(string SingpassID);

    }
}
