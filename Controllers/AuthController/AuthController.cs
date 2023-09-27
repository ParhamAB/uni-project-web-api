using Microsoft.AspNetCore.Mvc;
using uni_project.Core.Entity.AuthModel;
using uni_project.Core.Entity.ReturnModels;
using uni_project.Core.Entity.UserModels.NationalCodeModel;
using uni_project.Repositrory.AuthRepository;
using uni_project.Repositrory.UserRepository;

namespace uni_project.Controllers.AuthController
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly AuthRepository _authRepository;
        public AuthController(AuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost(Name = "Login")]
        public IActionResult Login([FromBody] AuthUserPassModel userPassModel)
        {
            try
            {
                BaseResponseModel result = _authRepository.Login(userPassModel);
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
