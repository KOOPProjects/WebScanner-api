using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner_api.DTOContainers
{
    public class ResponseDTO
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string Date { get; set; }
    public string Content { get; set; }
    public string Type { get; set; }

    public ResponseDTO(int id, int orderId, string date, string content, string type)
    {
        Id = id;
        OrderId = orderId;
        Date = date;
        Content = content;
        Type = type;
    }
}
}
