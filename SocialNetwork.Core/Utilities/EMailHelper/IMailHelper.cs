using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Utilities.EMailHelper
{
    public interface IMailHelper
    {
        bool SendEmail(string email,string token,   bool bodyHtml);
    }
}
