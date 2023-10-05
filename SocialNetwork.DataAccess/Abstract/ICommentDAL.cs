using SocialNetwork.Core.Configuration;
using SocialNetwork.Core.DataAccess;
using SocialNetwork.Core.DataAccess.EntityFramework;
using SocialNetwork.DataAccess.Concrete.EntityFramework;
using SocialNetwork.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Abstract
{
    public interface ICommentDAL : IRepositoryBase<Comment>
    {
    }
}
