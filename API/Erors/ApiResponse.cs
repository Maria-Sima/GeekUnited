namespace API.Errors;

public class ApiResponse
{
    public ApiResponse(int statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }

    private string GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "Caught in a bad request, oh no, oh no",
            401 => "Tryin' to sneak in, but you're stuck,401 and you're stuck",
            404 => "Where did that resource go, my dear 404?",
            500 => "Server crash, our app's gone haywire",
            _ => null
        };
    }
}