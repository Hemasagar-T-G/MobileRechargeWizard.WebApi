namespace MobileRechargeWizard.WebApi.Dto
{
    public class ApiResponseDto<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }

        public ApiResponseDto(T data, bool success, string message, string errorMessage = null)
        {
            Data = data;
            Success = success;
            Message = message;
            ErrorMessage = errorMessage;
        }
    }

}
