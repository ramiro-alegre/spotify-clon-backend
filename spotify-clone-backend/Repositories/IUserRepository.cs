﻿using spotify_clone_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify_clone_backend.Repositories
{
    public interface IUserRepository
    {
        public User GetUserWithEmail(string email, string password);
    }
}
