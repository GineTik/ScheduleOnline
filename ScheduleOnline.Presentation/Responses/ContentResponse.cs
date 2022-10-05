namespace ScheduleOnline.Presentation.Responses
{
    public class ContentResponse : Response
    {
        public object Content { get; set; }

        public ContentResponse(int statusCode, object content) : base(statusCode)
        {
            Content = content;
        }

        public static ContentResponse SuccessWithContent(object content) => new ContentResponse(200, content);
    }
}
