using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vim.Core.Application.IConfigurations;
using Vim.Dtos;
using Vim.Services;
using Vim.Wrappers;

namespace Vim.Controllers
{

    public class MaterialsController : BaseApiController
    {
        
        private readonly ILogger<MaterialsController> _logger;
        private readonly MaterialService _materialService;

        public MaterialsController(ILogger<MaterialsController> logger, MaterialService materialService)
        {
            _logger = logger;
            _materialService = materialService;
        }

        [HttpPost("add-material")]
        public async Task<ActionResult> AddNewMaterial(MaterialDto mat)
        {
            if (ModelState.IsValid)
            {
                var isAdded = await _materialService.AddNewMaterial(mat);
                if (isAdded)
                    return Ok(new ApiResponse<bool>(isAdded, 200, "Operation Successful"));
                return BadRequest(new ErrorResponse(400));
            }
            return BadRequest(new ErrorResponse(400));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteMaterial(string id)
        {
            var isDeleted = await _materialService.DeleteMaterial(id);
            if (isDeleted)
            {
                return Ok(new ApiResponse<bool>(isDeleted, 200, "Deleted Successfully"));
            }
            else
            {
                return BadRequest(new ErrorResponse(400));
            }
           
        }
    }
}
