using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScanner_api.Models.Database;
using WebScanner_api.Models.Repositories.Interfaces;

namespace WebScanner_api.Models.Repositories
{
    public class ResponseRepository : DbEntityRepository<Response>, IResponseRepository
    {
        public ResponseRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public IEnumerable<Response> GetMany(int[] ids)
        {
            return this.DatabaseContext.Responses.Where(x => ids.Contains(x.OrderId));
        }

        public IEnumerable<Response> GetResponseByIdDateAndContent(int[] ids, string type, DateTime dateAfter, DateTime dateBefore, string content)
        {
            return this.DatabaseContext.Responses.Where(
                x =>  ids.Contains(x.OrderId)
                    && x.Type==type
                    && (dateAfter.CompareTo(x.Date) <= 0)
                    && (dateBefore.CompareTo(x.Date) >= 0)
                    && x.Content.ToLower().Contains(content.ToLower())
                );
        }
    }
}
