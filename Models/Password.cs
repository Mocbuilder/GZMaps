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

            if(_passwordInput == "LemmyIsGod")
            {
                Process.Start(new ProcessStartInfo { FileName = "https://youtu.be/fM1UPeAOyHM?si=B5QVM3Gl32ScGb6w", UseShellExecute = true });
            }
        
            if (_passwordInput == "PrinceOfFuckingDarkness")
            {
                Process.Start(new ProcessStartInfo { FileName = "https://youtu.be/S6A13bOB76A?si=bw6tJRjNZ_Gt4rA7", UseShellExecute = true });
            }

            if (_passwordInput == "ComeTouchMyMetalMachine")
            {
                Process.Start(new ProcessStartInfo { FileName = "https://youtube.com/shorts/mTQffwXF1k8?si=QN8msGXkStp0srmz", UseShellExecute = true });
            }

            if (_passwordInput == "MetalGods")
            {
                Process.Start(new ProcessStartInfo { FileName = "https://youtu.be/CLWlCQZy87g?si=nNuZagMzejflPyff", UseShellExecute = true });
            }

            return new PasswordResult(_passwordInput == _storedPassword);
        }
    }
}
