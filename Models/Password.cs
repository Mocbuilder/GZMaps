namespace GZMaps.Models
{
    public class Password
    {
        public string _passwordInput { get; set; }
        private string _storedPassword = "";

        public Password(string passwordInput, IConfiguration config)
        {
            _passwordInput = passwordInput;

            _storedPassword = "1234";
            if(Program._environment == EnvironmentEnum.Production)
            {
                _storedPassword = config["EditorPassword"] ?? _storedPassword;
            }
        }

        public PasswordResult IsValid()
        {
            return new PasswordResult(!string.IsNullOrEmpty(_passwordInput) && _passwordInput == _storedPassword);
        }
    }
}
