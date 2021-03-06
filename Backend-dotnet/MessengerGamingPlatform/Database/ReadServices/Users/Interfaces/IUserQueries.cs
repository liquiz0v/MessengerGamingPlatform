﻿using Database.DTO;
using Database.Models;

namespace Database.ReadServices.Users.Interfaces
{
    public interface IUserQueries
    {
        public CreateUser GetUserIdByTelegram(string telegramid);
        public CreateUser GetUserIdByDiscord(string discordid);
        public User GetUserByUserId(int UserId);

    }
}