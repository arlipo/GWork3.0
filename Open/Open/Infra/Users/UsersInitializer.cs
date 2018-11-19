using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;
using Open.Data.Users;

namespace Open.Infra.Users
{
    public static class UsersInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Goods.Any()) return;
            usersList(c);
            c.SaveChanges();
        }

        private static void usersList(SentryDbContext c)
        {
            //var l = new List<string>
            //{
            //    add(c, new UsersData
            //    {
            //        Login = "Yana@yana.com",
            //        Password = "yanayana",
            //    }),
            //    add(c, new UsersData{
            //        Login = "Luiza@luiza.com",
            //        Password = "luizaluiza"
            //         }),
            //    add(c, new UsersData
            //    {
            //        Login = "Artjom@artjom.com",
            //        Password = "artjomartjom"
            //    }),
            //    add(c, new UsersData
            //    {
            //        Login = "Mark@mark.com",
            //        Password = "markmark"

            //    })
            //};
        }
        private static string add(SentryDbContext c, UsersData users)
        {
            users.ID = Guid.NewGuid().ToString();
            c.Users.Add(users);
            return users.ID;
        }
    }
}
