using Dapper;
using System.Data;
using System.Data.SqlClient;
using uni_project.Core.Entity.AddUserModel;
using uni_project.Core.Entity.ReturnModels.AddModel;
using uni_project.Core.Entity.UserModel;

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
                            "GetAllUsers",
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
            catch (Exception)
            {
                return new List<UserModel>();
            }

        }

        public AddModel AddUser(AddUserModel addUserModel)
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
                    parameters.Add("Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 255); // Adjust the size as needed

                    sql.Execute("InsertUser", parameters, commandType: CommandType.StoredProcedure);

                    string message = parameters.Get<string>("Message");

                    if (string.IsNullOrEmpty(message))
                    {
                        return new AddModel(true, "added successfully");
                    }
                    else
                    {
                        return new AddModel(false, message);
                    }
                }
            }
            catch (Exception ex)
            {
                return new AddModel(false, ex.ToString());
            }

        }
    }
}
