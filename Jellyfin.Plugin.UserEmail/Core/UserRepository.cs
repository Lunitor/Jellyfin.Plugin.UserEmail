using LiteDB;
using MediaBrowser.Controller.Library;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Jellyfin.Plugin.UserEmail.Core
{
    internal class UserRepository
    {
        private const string DatabaseName = @"useremails.db";
        private const string UserCollectionName = "users";
        private readonly IUserManager _userManager;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(IUserManager userManager, ILogger<UserRepository> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public void SyncWithJellyfinUsers()
        {
            var jellyfinUsers = _userManager.Users;

            using var db = new LiteDatabase(DatabaseName);
            var userCollection = GetUserCollection(db);

            var deletedUsersCount = userCollection.DeleteMany(u => !jellyfinUsers.Any(ju => ju.Username == u.Username));

            _logger.LogInformation("{deletedUsersCount} users deleted from UserEmail plugin database during sync", deletedUsersCount);
        }

        public IEnumerable<User> GetAll()
        {
            using var db = new LiteDatabase(DatabaseName);
            var userCollection = GetUserCollection(db);

            return userCollection.FindAll();
        }

        public void UpdateUserEmail(string username, string emailAddress)
        {
            using var db = new LiteDatabase(DatabaseName);

            var userCollection = GetUserCollection(db);

            var user = new User(username, emailAddress);

            userCollection.Upsert(user);
            _logger.LogInformation("{Username} user upserted to UserEmail plugin database", user.Username);
        }

        private static ILiteCollection<User> GetUserCollection(LiteDatabase db)
        {
            var userCollection = db.GetCollection<User>(UserCollectionName);
            userCollection.EnsureIndex(u => u.Username);
            return userCollection;
        }
    }
}
