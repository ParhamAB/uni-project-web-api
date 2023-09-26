namespace uni_project.Core.Entity.ReturnModels
{
    public class BaseResponseModel
    {
        public bool isSuccess { get; set; }
        public dynamic value { get; set; }

        public BaseResponseModel(bool isSuccess, dynamic value)
        {
            this.isSuccess = isSuccess;
            this.value = value;
        }
    }
}
