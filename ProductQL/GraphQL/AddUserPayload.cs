﻿using ProductQL.Models;

namespace ProductQL.GraphQL
{
    public class AddUserPayload
    {
       public AddUserPayload(User user)
        {
            User = user;
        }

        public User User { get; }
    }

}

