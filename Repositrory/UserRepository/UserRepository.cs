using System.Text.RegularExpressions;
using uni_project.Core.Entity.AddUserModel;
using uni_project.Core.Entity.ReturnModels;
using uni_project.Core.Entity.ReturnModels.AddModel;
using uni_project.Core.Entity.ReturnModels.MessageModel;
using uni_project.Core.Entity.UserModel;
using uni_project.Core.Extentions;
using uni_project.DataBase;

namespace uni_project.Repositrory.UserRepository
{
    public class UserRepository
    {

        private readonly UserDB _userDB;
        private readonly Validations _validation;
        public UserRepository(UserDB userDB, Validations validation)
        {
            _userDB = userDB;
            _validation = validation;
        }

        public BaseResponseModel GetAllUsers(string name,string nationalCode,int page,int offset)
        {
            try
            {
                IEnumerable<UserModel> result = _userDB.GetUsers(name, nationalCode, page, offset);
                return new BaseResponseModel(false, true, result);
            }catch(Exception ex) 
            {
                return new BaseResponseModel(true, false, new MessageModel(ex.ToString()));
            }
            
        }

        public BaseResponseModel AddUser(AddUserModel userModel)
        {
            if (string.IsNullOrEmpty(userModel.FirstName) || userModel.FirstName == "string")
            {
                return new BaseResponseModel(true, false, new MessageModel("لطفا نام خود را وارد کنید"));
            }

            if (string.IsNullOrEmpty(userModel.LastName) || userModel.LastName == "string")
            {
                return new BaseResponseModel(true, false, new MessageModel("لطفا نام خانوادگی خود را وارد کنید"));
            }

            if (!_validation.NationalValidation(userModel.NationalCode) || userModel.NationalCode == "string")
            {
                return new BaseResponseModel(true, false, new MessageModel("لطفا کد ملی صحیح وارد کنید"));
            }

            if (_validation.IsMobileNumber(userModel.PhoneNumber) || userModel.PhoneNumber == "string")
            {
                return new BaseResponseModel(true, false, new MessageModel("لطفا شماره تلفن صحیح وارد کنید"));
            }   

            if (string.IsNullOrEmpty(userModel.Job) || userModel.Job == "string")
            {
                return new BaseResponseModel(true, false, new MessageModel("لطفا شغل را وارد کنید"));
            }

            if (string.IsNullOrEmpty(userModel.FieldofStudy) || userModel.FieldofStudy == "string")
            {
                return new BaseResponseModel(true, false, new MessageModel("لطفا رشته و محل تحصیل خود را وارد کنید"));
            }
            try
            {
                AddModel result = _userDB.AddUser(userModel);
                return new BaseResponseModel(false, true, result);
            }
            catch (Exception ex)
            {
                return new BaseResponseModel(true, false, new MessageModel(ex.ToString()));
            }
        }
    }
}
