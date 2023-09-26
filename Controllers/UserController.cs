using Microsoft.AspNetCore.Mvc;
using uni_project.Core.Entity.AddUserModel;
using uni_project.Core.Entity.ReturnModels;
using uni_project.Repositrory.UserRepository;

namespace uni_project.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        [HttpGet(Name = "GetAllUsers")]
        public IActionResult GetAllUsers(string? name = "", string? nationalCode = "",int page = 1, int offset = 15)
        {
            try
            {
                BaseResponseModel result = _userRepository.GetAllUsers(name,nationalCode,page,offset);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
                
            }catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] AddUserModel addUser)
        {
            try
            {
                BaseResponseModel result = _userRepository.AddUser(addUser);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
