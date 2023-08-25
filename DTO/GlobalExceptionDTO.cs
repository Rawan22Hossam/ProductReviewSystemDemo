namespace ProductReviewSystemDemo.DTO
{
    public class GlobalExceptionDTO : Exception
    {
        private int statusCode;
        private string message;
        private string messageNullable;
        public GlobalExceptionDTO(int statusCode, string message)
        {
        }

        public GlobalExceptionDTO(int statusCode, string message, string? messageNullable) : base(message)
            {
            }
        

    }
}
/* 
        public GlobalExceptionDTO(int statusCode, string message)
        {
            this.statusCode = statusCode;
            this.message = message;
        }

        public GlobalExceptionDTO(int statusCode, string message, string? messageNotNullable) : this(statusCode, message)
        {
            this.messageNotNullable = messageNotNullable;
        }
 */