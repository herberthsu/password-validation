namespace PasswordValidation.Rules
{
    public struct ValidationError
    {
        public string Type { get; }
        public string Message { get; }

        public ValidationError(string type, string message)
        {
            Type = type;
            Message = message;
        }
    }
}