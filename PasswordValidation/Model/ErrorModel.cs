namespace PasswordValidation.Model
{
    public class ErrorModel
    {
        public bool IsSuccess { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }

        public ErrorModel(string type, string message)
        {
            IsSuccess = false;
            Type = type;
            Message = message;
        }
    }
}