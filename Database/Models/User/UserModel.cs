﻿using Common.Base;

namespace Database.Models.User
{
    public class UserModel : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}