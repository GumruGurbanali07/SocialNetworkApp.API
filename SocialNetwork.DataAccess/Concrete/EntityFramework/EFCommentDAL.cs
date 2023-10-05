using SocialNetwork.Core.Configuration;
using SocialNetwork.Core.DataAccess.EntityFramework;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Concrete.EntityFramework
{
    public class EFCommentDAL : EFRepositoryBase<Comment, AppDbContext>, ICommentDAL
    {
    }
}
