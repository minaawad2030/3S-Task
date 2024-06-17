namespace Task01.API.DTOs.Responses
{
    public class Response
    {
        public string Message { get; set; }
        public string Path { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }

    public class Response<T> : Response
    {
        public T Data { get; set; }
    }
}
