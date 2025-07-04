﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Saul.Test.Infrastructure.Notification.Options
{
    public class SendgridOptionsSetup : IConfigureOptions<SendgridOptions>
    {
        private const string ConfigurationSectionName = "Sendgrid";
        private readonly IConfiguration _configuration;

        public SendgridOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(SendgridOptions options)
        {
            _configuration.GetSection(ConfigurationSectionName).Bind(options);
        }
    }
}
