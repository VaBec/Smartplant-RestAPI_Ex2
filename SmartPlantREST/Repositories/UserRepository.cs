﻿using MongoDB.Bson;
using MongoDB.Driver;
using SmartPlantREST.Models;
using SmartPlantREST.Repositories;
using System;

namespace SmartPlantREST.DB
{
    public class UserRepository : IUserRepository
    {
        private IMongoDatabase plantDb;

        public UserRepository(MongoDbContext db)
        {
            plantDb = db.GetPlantDb();
        }

        public RepositoryResult Delete(RESTUserModel model)
        {
            var result = new RepositoryResult();

            try
            {
                var userDb = plantDb.GetCollection<UserModel>("user");
                var user = userDb.Find(u => u.Name == model.Username).FirstOrDefault();

                if (user == null)
                {
                    result.Successful = false;
                    result.Payload = "Could not find user with name " + model.Username;
                }
                else
                {
                    if (user.Password == model.Password)
                    {
                        userDb.DeleteOne(u => u.Name == model.Username);

                        result.Successful = true;
                        result.Payload = "Successfully deleted user.";
                    }
                    else
                    {
                        result.Successful = false;
                        result.Payload = "Wrong password.";
                    }
                }
            }
            catch (Exception e)
            {
                result.Successful = false;
                result.Payload = e.Message;
            }

            return result;
        }

        public RepositoryResult Register(RESTUserModel model)
        {
            var result = new RepositoryResult();
            try
            {
                var userDb = plantDb.GetCollection<UserModel>("user");
                var user = userDb.Find(u => u.Name == model.Username).FirstOrDefault();

                if (user == null)
                {
                    user = new UserModel();
                    user.Id = ObjectId.GenerateNewId().ToString();
                    user.Name = model.Username;
                    user.Password = model.Password;
                    userDb.InsertOne(user);

                    result.Successful = true;
                    result.Payload = $"Successfully reigstered user '{model.Username}'.";
                }
                else
                {
                    result.Successful = false;
                    result.Payload = $"User '{model.Username}' already exists.";
                }
            }
            catch (Exception e)
            {
                result.Successful = false;
                result.Payload = e.Message;
            }

            return result;
        }

        public RepositoryResult Delete(string name)
        {
            var result = new RepositoryResult();

            try
            {
                var userDb = plantDb.GetCollection<UserModel>("user");
                var deleteResult = userDb.DeleteOne(u => u.Name == name);

                if (!deleteResult.IsAcknowledged)
                {
                    result.Successful = false;
                    result.Payload = $"Cant delete user '{name}'";
                }
                else
                {
                    result.Successful = true;
                    result.Payload = $"Successfully deleted user '{name}'";
                }
            }
            catch (Exception e)
            {
                result.Successful = false;
                result.Payload = e.Message;
            }

            return result;
        }


        public RepositoryResult LoginUser(RESTUserModel model)
        {
            var result = new RepositoryResult();

            try
            {
                var userDb = plantDb.GetCollection<UserModel>("user");
                var user = userDb.Find(u => u.Name == model.Username && u.Password == model.Password).FirstOrDefault();
                if (user == null)
                {
                    result.Successful = false;
                    result.Payload = $"Cant login user '{model.Username}'";
                }
                else
                {
                    result.Successful = true;
                    result.Payload = $"Successfully logged in user '{model.Username}'";
                }
            }
            catch (Exception e)
            {
                result.Successful = false;
                result.Payload = e.Message;
            }

            return result;
            }

            public RepositoryResult GetUser(string name)
            {
            var result = new RepositoryResult();

            try
            {
                var userDb = plantDb.GetCollection<UserModel>("user");
                var user = userDb.Find(u => u.Name == name).FirstOrDefault();
                if (user == null)
                {
                    result.Successful = false;
                    result.Payload = $"Cant find user '{name}'";
                }
                else
                {
                    result.Successful = true;
                    result.Payload = user;
                }
            }
            catch (Exception e)
            {
                result.Successful = false;
                result.Payload = e.Message;
            }

            return result;
        }

        public RepositoryResult GetUsers()
        {
            var result = new RepositoryResult();
            try
            {
                result.Successful = true;

                var userDb = plantDb.GetCollection<UserModel>("user");
                var users = userDb.Find(user => true).ToList();
                users.ForEach(user => user.Password = string.Empty);

                result.Payload = users;
            }
            catch (Exception e)
            {
                result.Successful = false;
                result.Payload = e.Message;
            }

            return result;
        }

        public UserModel GetUserByName(string userName)
        {
            var userDb = plantDb.GetCollection<UserModel>("user");
            return userDb.Find(u => u.Name == userName).FirstOrDefault();
        }
    }
}
