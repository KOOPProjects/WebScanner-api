namespace WebScanner_api.DTOContainers
{
    public class ErrorApiResponse : ApiResponse
    {
        public string Message { get; set; }

        public ErrorApiResponse(string message) : base("error")
        {
            Message = message;
        }
    }
}
