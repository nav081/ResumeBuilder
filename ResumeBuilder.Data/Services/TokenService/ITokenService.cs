using ResumeBuilder.Data.Models.Common;
using System;
using System.Collections.Generic;

namespace ResumeBuilder.Data.Services.TokenService
{
    public interface ITokenService
    {
        void Delete(string token);

        List<Token> AllInActive(DateTime time);
    }
}
