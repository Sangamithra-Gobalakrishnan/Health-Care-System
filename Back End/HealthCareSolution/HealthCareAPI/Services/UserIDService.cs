using HealthCareAPI.Interfaces;

namespace HealthCareAPI.Services
{
    public class UserIDService : IGenerateUserId
    {
        public async Task<string> GenerateUserId(string role, int count)
        {
            if(role == "admin")
            {
                string userID = "ADM0";
                if (count < 10 && count >= 0)
                    userID += "0" + (++count);
                else
                    userID += ++count;
                return userID;
            }
            else if(role == "doctor")
            {
                string userID = "DOC0";
                if (count < 10 && count >= 0)
                    userID += "0" + (++count);
                else
                    userID += ++count;
                return userID;
            }
            else
            {
                string userID = "PAT0";
                if (count < 10 && count >= 0)
                    userID += "0" + (++count);
                else
                    userID += ++count;
                return userID;
            }
           
        }
    }
}
