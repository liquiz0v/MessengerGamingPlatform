﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Database.DTO;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
//using System.Configuration;
using Api;

namespace Api.Sessions
{
    public class SessionQueries
    {
        private string connectionString = "Server=25.98.56.253;Database=MGP;MultipleActiveResultSets=true;User ID=sa;Password=OKTyaBRSkOE123;";
        public SessionQueries()
        {

        }
        public List<SessionParticipants> GetSessionParticipants(int SessionId)
        {
            string sqlquery = @$"select Users.Username, UsersSessionsMedievalBattle.SessionMedievalBattleId
            from dbo.SessionMedievalBattles
            full join UsersSessionsMedievalBattle on UsersSessionsMedievalBattle.SessionMedievalBattleId = SessionMedievalBattles.SessionMedievalBattleId
            full join Users on Users.UserId = UsersSessionsMedievalBattle.UserId
            where SessionMedievalBattles.SessionMedievalBattleId = {SessionId};";

            var participants = new List<SessionParticipants>();

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                participants = db.Query<SessionParticipants>(sqlquery).ToList();
            }

            return participants;
        }

        public Session GetSession(int UserId)
        {
            string sqlquery = $@"select * from UsersSessionsMedievalBattle
            join SessionMedievalBattles on SessionMedievalBattles.SessionMedievalBattleId = UsersSessionsMedievalBattle.SessionMedievalBattleId
            where UsersSessionsMedievalBattle.UserId = {UserId}";

            var session = new Session();

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                session = db.Query<Session>(sqlquery).FirstOrDefault();
            }

            return session;
        }

        public GetUsersSessionsMedievalBattle GetUsession(int UserId)
        {
            string sqlquery = $@"select * from UsersSessionsMedievalBattle where UserId = {UserId}";

            var usession = new GetUsersSessionsMedievalBattle();

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                usession = db.Query<GetUsersSessionsMedievalBattle>(sqlquery).FirstOrDefault();
            }

            return usession;
        }

        // Open sessions listing
        public List<Session> GetSessionViaStatus()
        {
            string sqlquery = $@"select * from SessionMedievalBattles where Status = 1";

            var session = new List<Session>();

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                session = db.Query<Session>(sqlquery).ToList();
            }

            return session;
        }
    }
}
