using System.Text.RegularExpressions;
using uni_project.Core.Entity.UserModel;

namespace uni_project.Core.Extentions
{
    public class Validations
    {
        public bool NationalValidation(string code)
        {
            if (!Regex.IsMatch(code, @"^\d{10}$"))
                return false;
            var check = Convert.ToInt32(code.Substring(9, 1));
            var sum = Enumerable.Range(0, 9)
                .Select(x => Convert.ToInt32(code.Substring(x, 1)) * (10 - x))
                .Sum() % 11;
            return sum < 2 ? check == sum : check + sum == 11;
        }

        public bool IsMobileNumber(string mobile)
        {
            return !Regex.IsMatch(mobile, @"^09\d{9}$");
        }
    }
}
