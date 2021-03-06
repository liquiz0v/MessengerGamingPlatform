﻿using System.Collections.Generic;
using Database.DTO;

namespace Database.ReadServices.Sessions.Interfaces
{
    public interface ISessionReadService
    {
        public List<SessionParticipants> GetSessionsParticipants(int SessionId);
        public Session CreateSessionMedievalBattles(int UserId);
        public Session GetSession(int UserId);
        public List<Session> GetOpenSessions();
        public Session JoinSession(int UserId);
        public bool LeaveSession(int UserId);
    }
}