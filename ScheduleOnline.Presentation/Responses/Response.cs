namespace ScheduleOnline.Presentation.Responses
{
    public class Response
    {
        public int StatusCode { get; set; }
        public bool Successfully => StatusCode == 200;

        public Response(int statusCode)
        {
            StatusCode = statusCode;
        }

        public static Response Success => new Response(200);
        public static Response Error => new Response(400);
        public static Response AuthorizeError => new Response(403);
    }
}
