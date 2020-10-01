namespace MarkDocsAppContracts.DTO
{
    public class AppResponseError : Response
    {
        public string Message { get; }
        public AppResponseError(string msg)
        {
            Message = msg;
        }
    }
}
