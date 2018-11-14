using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner_api.Models
{
    public class OrderResponse
    {
        private int id;
        private int orderId;
        private DateTime receivedDatetime;
        private string responseContent;

        public int Id { get { return id; } set { id = value; } }
        public int OrderId { get { return orderId; } set { orderId = value; } }
        public DateTime ReceivedDatetime { get { return receivedDatetime; } set { receivedDatetime = value; } }
        public string ResponseContent { get { return responseContent; } set { responseContent = value; } }

        public OrderResponse(int id, int orderId, DateTime receivedDatetime, string content)
        {
            this.id = id;
            this.orderId = orderId;
            this.receivedDatetime = receivedDatetime;
            this.responseContent = content;
        }
    }
}
