using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnibetClient.DTO;

namespace UnibetClient
{
    public interface IUnibetClient
    {
        /// <summary>
        /// Login to unibet 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        Task<bool> Login(string username, string password, string birthDate);

        /// <summary>
        /// Get every bet done between given dates
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<List<BetDto>> GetBetsHistory(DateTime startDate, DateTime endDate);
    }
}