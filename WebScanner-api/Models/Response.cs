﻿using System;
using System.Collections.Generic;
namespace WebScanner_api.Models
{
    public class Response : DbEntity
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
      
        public Response(int id, int orderId, DateTime date, string content)
        {
            Id = id;
            OrderId = orderId;
            Date = date;
            Content = content;
        }
    }
}
