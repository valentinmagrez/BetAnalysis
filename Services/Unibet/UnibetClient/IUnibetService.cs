using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnibetClient.DTO;

namespace UnibetClient
{
    public interface IUnibetService
    {
        Task Login(string username, string password, string birthDate);
        Task<List<BetDto>> GetBetsHistory(DateTime from, DateTime to);
        Task<List<BetDto>> GetAllBets();
    }
}