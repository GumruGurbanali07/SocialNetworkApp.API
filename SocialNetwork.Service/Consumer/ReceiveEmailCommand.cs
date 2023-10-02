using MassTransit;
using SocialNetwork.Core.Utilities.EMailHelper;
using SocialNetwork.Entities.SharedEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business.Consumer
{
    public class ReceiveEmailCommand : IConsumer<SendEmailCommand>
    {
        private readonly IMailHelper _mailHelper;

        public ReceiveEmailCommand(IMailHelper mailHelper)
        {
            _mailHelper = mailHelper;
        }

        public async  Task Consume(ConsumeContext<SendEmailCommand> context)
        {
            _mailHelper.SendEmail(context.Message.Email, context.Message.Token, true);
        }
    }
}
