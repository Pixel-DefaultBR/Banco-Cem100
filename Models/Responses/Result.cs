namespace BancoCem.Models.Responses
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public T Value { get; private set; }

        private Result(bool isSuccess, T value, string errorMessage)
        {
            IsSuccess = isSuccess;
            Value = value;
            ErrorMessage = errorMessage;
        }

        private Result(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(true, value, string.Empty);
        }

        public static Result<T> Failure(string errorMessage)
        {
            return new Result<T>(false, default!, errorMessage);
        }
    }
}
