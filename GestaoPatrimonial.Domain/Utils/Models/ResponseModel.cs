namespace GestaoPatrimonial.Domain.Utils.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Content { get; set; }

        public ResponseModel(int statusCode)
        {
            StatusCode = statusCode;
        }

        public ResponseModel(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public ResponseModel(int statusCode, object content, string message = "")
        {
            StatusCode = statusCode;
            Content = content;
            Message = message;
        }
    }
}
