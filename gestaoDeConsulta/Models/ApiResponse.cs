namespace gestaoDeConsulta.Models
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; }
        public T Data { get; set; }

        public static ApiResponse<T> Success(T data, string message = "OK")
        {
            return new ApiResponse<T>
            {
                IsSuccess = true,
                StatusCode = 200,
                Message = message,
                Data = data
            };
        }

        public static ApiResponse<T> Fail(int statusCode = 400, string message = "Falha na requisição")
        {
            return new ApiResponse<T>
            {
                Data = default,
                IsSuccess = false,
                Message = message,
                StatusCode = statusCode,

            };
        }

    }
}
