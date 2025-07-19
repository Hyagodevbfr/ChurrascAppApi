using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChurrascApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public string Id
        {
            get
            {
                return this.User.Claims.FirstOrDefault(c => c.Type == "Id")!.Value;
            }
        }
    }
}
