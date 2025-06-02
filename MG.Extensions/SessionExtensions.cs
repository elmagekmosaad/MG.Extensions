using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MG.Extensions.Session
{
    public static class SessionExtensions
    {
        public static void SetUserSessionData(this ISession session, UserSessionData userSessionData)
        {
            if (userSessionData.Avatar == null)
            {
                userSessionData.Avatar = string.IsNullOrEmpty(userSessionData.Name) ? "https://ui-avatars.com/api/?name=Guest" : "https://ui-avatars.com/api/?name=" + userSessionData.Name;
            }

            if (userSessionData.Roles == null)
            {
                userSessionData.Roles = "User";
            }

            session.SetString("UserSessionData", JsonConvert.SerializeObject(userSessionData));
        }

        public static UserSessionData GetUserSessionData(this ISession session)
        {
            var userSessionDataJson = session.GetString("UserSessionData");
            return userSessionDataJson == null ? null : JsonConvert.DeserializeObject<UserSessionData>(userSessionDataJson);
        }
    }

}