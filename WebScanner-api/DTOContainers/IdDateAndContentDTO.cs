using System;

namespace WebScanner_api.DTOContainers
{
    public class IdDateAndContentDTO
    {
        public int[] OrderIds { get; private set; }
        public DateTime DateAfter { get; private set; }
        public DateTime DateBefore { get; private set; }
        public string Content { get; private set; }

        public IdDateAndContentDTO(int[] orderIds, DateTime? dateAfter = null, DateTime? dateBefore = null, string content = null)
        {
            OrderIds = orderIds;
            DateAfter = dateAfter == null ? DateTime.MinValue : (DateTime)dateAfter;
            DateBefore = dateBefore == null ? DateTime.MaxValue : (DateTime)dateBefore;
            Content = content == null ? "" : content;
        }
    }
}
