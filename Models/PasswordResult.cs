namespace GZMaps.Models
{
    public class PasswordResult
    {
        public bool IsValid { get; set; }
        public PasswordResult(bool isValid)
        {
            IsValid = isValid;
        }
    }
}
