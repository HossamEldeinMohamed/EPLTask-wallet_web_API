using BusinessLayer.IService;
using Common_Utility.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EPLTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TransformationController : ControllerBase
    {
        private readonly ITransformationService transformationService;

        public TransformationController(ITransformationService transformationService)
        {
            this.transformationService = transformationService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTransformation(TranformationDTO model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity;
                var x = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                //model.UserId = userId;
                var result = await transformationService.CreateTransformation(model);
                return StatusCode(result.Code, result);
            }
            return BadRequest();

        }
    }
}
