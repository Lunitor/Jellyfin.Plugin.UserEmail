using Jellyfin.Plugin.UserEmail.Core;
using MediaBrowser.Model.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Jellyfin.Plugin.UserEmail.API
{
    public class UserEmailsAPI
    {
        private readonly ILogger<UserEmailsAPI> _logger;
        private readonly IUserRepository _userRepository;

        public UserEmailsAPI(ILogger<UserEmailsAPI> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public IEnumerable<User> Get(GetUserEmails request)
        {
            _logger.LogInformation($"{nameof(GetUserEmails)} requested");
            _logger.LogInformation("Sync users between Jellyfin db and plugin db");
            _userRepository.SyncWithJellyfinUsers();
            _logger.LogInformation("Sync finished");

            return _userRepository.GetAll();
        }
    }

    [Route("/Jellyfin.Plugin.UserEmail/GetUserEmails", verbs:"GET")]
    public class GetUserEmails : IReturn<IEnumerable<User>>
    { 
    }
}
