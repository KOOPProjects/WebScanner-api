using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner_api.Models
{
    public class ApiResponse
{
    private string status;
    public string Status { get { return status; } set { status = value; } }

    public ApiResponse(string status)
    {
        this.status = status;
    }
}
}
