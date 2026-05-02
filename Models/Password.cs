namespace GZMaps.Models
{
    public class Password
    {
        public string passwordInput { get; set; }
        private string _storedPassword;

        public Password(string _passwordInput, IConfiguration config)
        {
            passwordInput = _passwordInput;

            _storedPassword = "1234";
            if(Program._environment == EnvironmentEnum.Production)
            {
                _storedPassword = config["EditorPassword"];
            }
        }

        public PasswordResult IsValid()
        {
            return new PasswordResult(!string.IsNullOrEmpty(passwordInput) && passwordInput == _storedPassword);
        }
    }
}
