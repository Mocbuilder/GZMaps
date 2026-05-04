using System.Diagnostics;

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
            if (string.IsNullOrEmpty(_passwordInput))
            {
                return new PasswordResult(false);
            }

            return new PasswordResult(_passwordInput == _storedPassword);
        }
    }
}
