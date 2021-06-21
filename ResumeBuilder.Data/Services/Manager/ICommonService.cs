using ResumeBuilder.Data.Models.Common;
using ResumeBuilder.Data.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResumeBuilder.Data.Services.Manager
{
    public interface ICommonService
    {
        Task<User> GetUserByToken(string token,string ipadress);

        Task<User> GetUserByToken(string token);
        Task<string> GenerateToken(int userid, string ipaddress);
        Task<List<Token>> AllInActive(DateTime time);

    }
}
