using Jellyfin.Plugin.UserEmail.Configuration;
using Jellyfin.Plugin.UserEmail.Entity;
using MediaBrowser.Controller.Library;
using MediaBrowser.Model.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jellyfin.Plugin.UserEmail.API
{
    public class UserEmailsAPI : IService
    {
        private readonly ILogger<UserEmailsAPI> _logger;
        private readonly IUserManager _userManager;

        public UserEmailsAPI(ILogger<UserEmailsAPI> logger, IUserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IEnumerable<User> Get(GetUserEmails request)
        {
            _logger.LogInformation($"{nameof(GetUserEmails)} requested");

            var jellyfinUsers = _userManager.Users;

            return Plugin.Instance.Configuration.UserEmails
                .Where(u => jellyfinUsers.Any(ju => ju.Id == Guid.Parse(u.UserId)))
                .ToArray();
        }
    }

    [Route("/Jellyfin.Plugin.UserEmail/GetUserEmails", verbs:"GET")]
    public class GetUserEmails : IReturn<IEnumerable<User>>
    { 
    }
}
