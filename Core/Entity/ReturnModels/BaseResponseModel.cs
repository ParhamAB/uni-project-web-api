namespace uni_project.Core.Entity.ReturnModels
{
    public class BaseResponseModel
    {
        public bool isFailed { get; set; }
        public bool isSuccess { get; set; }
        public dynamic value { get; set; }

        public BaseResponseModel(bool isFailed, bool isSuccess, dynamic value)
        {
            this.isFailed = isFailed;
            this.isSuccess = isSuccess;
            this.value = value;
        }
    }
}
