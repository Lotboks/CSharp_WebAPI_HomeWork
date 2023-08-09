using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class02_Homework_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return Ok(StaticDb.UserNames);
        }

        [HttpGet("{index?}")]
        public ActionResult<string> GetByIndex(int? index)
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The index is a negative number.");
                }

                if (index >= StaticDb.UserNames.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"User with index: {index} was not found.");
                }

                return Ok(StaticDb.UserNames[(int)index]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured. Contact the support team.");
            }
        }
    }
}
