using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using uni_project.Core.Entity.ReturnModels.AddModel;
using uni_project.Core.Entity.ReturnModels.EditModel;
using uni_project.Core.Entity.User.AddUserModel;
using uni_project.Core.Entity.User.UserModel;
using uni_project.Core.Entity.UserModels.GetUserByNationalResponse;
using uni_project.Core.Entity.UserModels.NationalCodeModel;

namespace uni_project.DataBase
{
    public class UserDB
    {
        private readonly Connection _connection;
        public UserDB(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<UserModel> GetUsers(string name, string nationalCode, int page, int offset)
        {
            try
            {
                using (SqlConnection sql = _connection.GetConnection())
                {
                    return sql.Query<UserModel>(
                            "User_GetAllUsers",
                            new
                            {
                                NationalCodeSearch = nationalCode,
                                FirstNameSearch = name,
                                PageSize = offset,
                                PageNumber = page
                            },
                            commandType: CommandType.StoredProcedure
                        );
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public GetUserByNationalResponse GetUserByNationalCode(NationalCodeModel nationalCodeModel)
        {
            try
            {
                using (SqlConnection sql = _connection.GetConnection())
                {
                    return sql.QueryFirstOrDefault<GetUserByNationalResponse>(
                            "User_GetNamesByNationalCode",
                            new
                            {
                                nationalCodeModel.NationalCode
                            },
                            commandType: CommandType.StoredProcedure
                        );
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public EditModel AddUser(AddUserModel addUserModel)
        {
            try
            {
                using (SqlConnection sql = _connection.GetConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("FirstName", addUserModel.FirstName);
                    parameters.Add("LastName", addUserModel.LastName);
                    parameters.Add("PhoneNumber", addUserModel.PhoneNumber);
                    parameters.Add("NationalCode", addUserModel.NationalCode);
                    parameters.Add("FieldofStudy", addUserModel.FieldofStudy);
                    parameters.Add("LastDocument", addUserModel.LastDocument);
                    parameters.Add("Job", addUserModel.Job);
                    parameters.Add("JobAddress", addUserModel.JobAddress);
                    parameters.Add("Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 30);
                    parameters.Add("isUpdated", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                    sql.Execute("User_InsertUser", parameters, commandType: CommandType.StoredProcedure);

                    string message = parameters.Get<string>("Message");
                    bool isUpdated = parameters.Get<bool>("isUpdated");

                    return new EditModel(isUpdated, message);
                }
            }
            catch (Exception ex)
            {
                return new EditModel(false, ex.ToString());
            }
        }
    }
}
