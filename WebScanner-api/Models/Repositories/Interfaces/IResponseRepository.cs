using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner_api.Models.Repositories.Interfaces
{
    public interface IResponseRepository
    {
        IEnumerable<Response> GetResponseByIdDateAndContent(int[] ids, string type, DateTime dateAfter, DateTime dateBefore, string content);
        IEnumerable<Response> GetMany(int[] ids);
    }
}
