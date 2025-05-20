using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MG.Extensions.Session
{
    public static class SessionExtensions
    {
        public static void SetUserSessionData(this ISession session, UserSessionData userSessionData)
        {
            session.SetString("UserSessionData", JsonConvert.SerializeObject(userSessionData));
        }

        public static UserSessionData GetUserSessionData(this ISession session)
        {
            var userSessionDataJson = session.GetString("UserSessionData");
            return userSessionDataJson == null ? null : JsonConvert.DeserializeObject<UserSessionData>(userSessionDataJson);
        }
    }

}