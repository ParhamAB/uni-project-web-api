namespace uni_project.Core.Entity.ReturnModels.MessageModel
{
    public class MessageModel
    {
        public string Message { get; set; }

        public MessageModel(string message) 
        {
            Message = message;
        }
    }
}
