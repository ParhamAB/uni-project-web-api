namespace uni_project.Core.Entity.ReturnModels.DeleteModel
{
    public class DeleteModel
    {
        public bool IsDeleted { get; set; }
        public string Message { get; set; }

        public DeleteModel(bool isDeleted, string message)
        {
            IsDeleted = isDeleted;
            Message = message;
        }
    }
}
