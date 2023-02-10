using Vim.Core.Application.IConfigurations;
using Vim.Core.Entities;
using Vim.Dtos;

namespace Vim.Services
{
    public class MaterialService
    {
        private IUnitOfWork _unitOfWork;
        private ILogger<MaterialService> _logger;

        public MaterialService(IUnitOfWork unitOfWork, ILogger<MaterialService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> AddNewMaterial(MaterialDto matDto)
        {
            var material = new Materials
            {
                MaterialName = matDto.MaterialName,
                Url = matDto.Url,
                PictureUrl = matDto.PictureUrl,
                Description = matDto.Description,
                CreatedAt = DateTime.Now
            };
            var result = await _unitOfWork.Materials.AddAsync(material);
            await _unitOfWork.CompleteAsync();
            return result;
        }

    }
}
