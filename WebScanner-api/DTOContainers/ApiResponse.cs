namespace WebScanner_api.DTOContainers
{
    public class ApiResponse
{
    public string Status { get; set; }

        public ApiResponse(string status)
        {
            Status = status;
        }
    }
}
