namespace SinglePaymentAPI.Models.Responses
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public T Value { get; set; }

        private Result(bool isSuccess, string errorMessage, T value)
        {
            IsSuccess = isSuccess;
            Value = value;
            ErrorMessage = errorMessage;
        }

        private Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public static Result<T> Success(T value) => new Result<T>(true, null, value);
        public static Result<T> Failure(string errorMessage) => new Result<T>(false, errorMessage, default);
    }
}
