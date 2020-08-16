using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnibetService.UnibetApi.DTO;

namespace UnibetService.UnibetApi
{
    public interface IUnibetService
    {
        Task Login(string username, string password, string birthDate);
        Task<List<BetDto>> GetBetsHistory(DateTime from, DateTime to);
        Task<List<BetDto>> GetAllBets();
    }
}