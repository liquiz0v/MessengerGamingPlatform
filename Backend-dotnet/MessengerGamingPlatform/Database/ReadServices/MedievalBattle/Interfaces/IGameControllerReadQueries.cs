﻿using System.Collections.Generic;
using Database.DTO.MedievalBattleDTO;

namespace Database.ReadServices.MedievalBattle
{
    public interface IGameControllerReadQueries
    {
        public object GetTeamsCount(int sessionId); // Count of records in UsersSessions table
        public GetCoinsDTO GetCoins(int gameControllerId, int teamId);
        public object GetTurn(); // Is now your turn? OR Turn counter
        public object GetAvailableAreasCount(int userId);
        public object GetDefeatTeam(int gameControllerId); // Outputs defeated team id (userId)
        public object GetGameAvailable(int gameControllerId); // Availability of the game (is the game ended? yes: false, no: true)
        public object GetAreas(int areaId); // Get list of areas that matches userId
    }
}