namespace PasswordValidation.Rules
{
    public class ValidationResult
    {
        public string Message { get; set; }
        public string Type { get; set; }

        public bool IsValid { get; private set; }
        
        public ValidationResult()
        {
            IsValid = true;
        }
        
        public void SetError(ValidationError error)
        {
            IsValid = false;
            Type = error.Type;
            Message = error.Message;
        }
    }
}