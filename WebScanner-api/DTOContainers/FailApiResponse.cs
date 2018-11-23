namespace WebScanner_api.DTOContainers
{
    public class FailApiResponse : ApiResponse
    {
        public string Message { get; set; }

        public FailApiResponse(string message) : base("fail")
        {
            Message = message;
        }
    }
}
