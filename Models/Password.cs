namespace GZMaps.Models
{
    public class Password
    {
        public string _password { get; set; }

        public Password(string password)
        {
            _password = password;
        }

        public PasswordResult IsValid()
        {
            return new PasswordResult(!string.IsNullOrEmpty(_password) && _password == "1234");
        }
    }
}
