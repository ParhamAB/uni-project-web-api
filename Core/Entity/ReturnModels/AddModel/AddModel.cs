namespace uni_project.Core.Entity.ReturnModels.AddModel
{
    public class AddModel
    {
        public bool IsAdded { get; set; }
        public string Message { get; set; }

        public AddModel(bool isAdded,string message) 
        {
            IsAdded = isAdded;
            Message = message;
        }
    }
}
