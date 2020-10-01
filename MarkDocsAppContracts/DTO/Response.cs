using System.Threading.Tasks;

namespace MarkDocsAppContracts.DTO
{
    public class Response
    {
        public string ResponseType { get; }
        public Response()
        {
            ResponseType = this.GetType().Name;
        }

    }
}
