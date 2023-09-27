namespace uni_project.Core.Entity.AuthModel
{
    public class AuthResponseModel
    {
        public string Token { get; set; }
        public string Message { get; set; }

        public AuthResponseModel(string token,string message) 
        {
            Token = token;
            Message = message;
        }
    }
}
