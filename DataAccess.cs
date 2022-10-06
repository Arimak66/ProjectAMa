using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System;
using MySqlConnector;
using Dapper;

namespace ProjectAMa
{
    public class DataAccess
    {
       /* public List<User> GetUser(string username)
        {
            using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
            {
                var output = connection.Query<User>($"select * from users where username = '{username}';").ToList();
                //var output = connection.Query<Person>($"cmd.Users_GetUserByLastname @LastName", new {LastName=lname}).ToList();
                return output;
            }
        }
        public void InsertPerson(string username, string password, string identity, string firstname, string lastname)
        {
            using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
            {
                List<User> newUser = new List<User>();
                newUser.Add(new User { username = username, password = password, identity = identity, firstname = firstname });

                connection.Execute($"insert into users (username,password,identity,firstname,lastname) values ('{username}','{password}','{identity}','{firstname}''{lastname}')");
            }

        }*/


    }
}