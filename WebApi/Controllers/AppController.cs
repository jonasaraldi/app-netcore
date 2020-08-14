using CrossCutting.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class AppController : ControllerBase
    {
        public ActionResult ResultHandler<T>(T result)
            where T : BaseDto
        {
            return result.IsValid()
                ? (ActionResult)BadRequest(result)
                : (ActionResult)Ok(result);
        }
    }
}