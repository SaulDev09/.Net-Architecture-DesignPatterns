﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saul.Test.Application.Interface.Infrastructure;
using Saul.Test.Infrastructure.Notification.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Saul.Test.Infrastructure.Notification
{
    public class NotificationSendGrid : INotification
    {
        private readonly ILogger<NotificationSendGrid> _logger;
        private readonly SendgridOptions _options;
        private readonly ISendGridClient _sendGridClient;

        public NotificationSendGrid(ILogger<NotificationSendGrid> logger, IOptions<SendgridOptions> options, ISendGridClient sendGridClient)
        {
            _logger = logger;
            _options = options.Value;
            _sendGridClient = sendGridClient;
        }

        public async Task<bool> SendMail(string subject, string body, CancellationToken cancellationToken = default)
        {

            SendGridMessage message = BuildMessage(subject, body);
            Response? response = await _sendGridClient.SendEmailAsync(message).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"Email sent to {_options.ToAddress} at {response.Headers.Date}");
                return true;
            }

            _logger.LogInformation($"Email failed to {_options.ToAddress} with error code {response.StatusCode}");
            return false;
        }

        private SendGridMessage BuildMessage(string subject, string body)
        {
            SendGridMessage message = new SendGridMessage
            {
                From = new EmailAddress(_options.FromEmail, _options.FromUser),
                Subject = subject
            };

            message.AddContent(MimeType.Text, body);
            message.AddTo(new EmailAddress(_options.ToAddress, _options.ToUser));

            if (_options.SandboxMode)
            {
                message.MailSettings = new MailSettings { SandboxMode = new SandboxMode { Enable = true } };
            }
            return message;
        }
    }
}
