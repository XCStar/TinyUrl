using Microsoft.EntityFrameworkCore;
using TinyUrl.IDal;
using TinyUrl.Model;

namespace TinyUrl.Dal
{
    public class UrlItemDal : BaseDal<UrlItem>, IUrlItemDal
    {
 
        public UrlItemDal (EFContext dbContext) : base (dbContext)
        {
         
        }
    }
}