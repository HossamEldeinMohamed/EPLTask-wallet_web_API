
using BusinessLayer.IService;
using Helpers;
using Microsoft.AspNetCore.Mvc;

namespace EPLTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ILogService log;

        public ReportController(ILogService log)
        {
            this.log = log;
        }

        [HttpPost]
        public async Task<ActionResult> GetReport()
        {
            if (ModelState.IsValid)
            {
                var result = log.GetAll();
                if (result != null)
                {
                    return StatusCode(200, new Response { Data = result, Message = "Get Successfully" });
                }
                return StatusCode(400, new Response { Data = result, Message = "No data Exist" });
            }
            return StatusCode(501, new Response { Data = ModelState.Values.SelectMany(v => v.Errors), Message = "Not Implemented" });

        }
    }
}
