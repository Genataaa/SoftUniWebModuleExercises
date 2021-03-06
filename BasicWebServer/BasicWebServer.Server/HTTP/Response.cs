using System.Text;

namespace BasicWebServer.Server.HTTP
{
    public class Response
    {
        public Response(StatusCode statusCode)
        {
            this.StatusCode = statusCode;
            this.Headers = new HeaderCollection();

            this.Headers.Add(Header.Server, "My web server");
            this.Headers.Add(Header.Date, $"{DateTime.UtcNow:r}");
        }

        public StatusCode StatusCode { get; set; }

        public HeaderCollection Headers { get; set; }

        public string Body { get; set; }

        public Action<Request,Response> PreRenderAction { get; protected set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)this.StatusCode}{this.StatusCode}");

            foreach (var header in this.Headers)
            {
                result.AppendLine(header.ToString());
            }

            result.AppendLine();

            if (!string.IsNullOrEmpty(this.Body))
            {
                result.AppendLine(this.Body);
            }
            return result.ToString();
        }
    }
}
