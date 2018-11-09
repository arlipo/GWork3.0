using System;
using Open.Data.Users;

namespace Open.Domain.Users
{
  public static class UserFactory
        {
            public static User Create(UsersData data)
            {
                return new User(data);
            }
            public static User Create(string id, string name, string code, string phone,
                string address, string login, string password, DateTime? validFrom = null, DateTime? validTo = null)
            {
                UsersData db = new UsersData
                {
                    ID = id,
                    Name = name,
                    Code = code,
                    Phone = phone,
                    Address = address,
                    ValidFrom = validFrom ?? DateTime.MinValue,
                    ValidTo = validTo ?? DateTime.MaxValue,
                    Login = login,
                    Password = password
                };
                return new User(db);
            }
        }
    }

