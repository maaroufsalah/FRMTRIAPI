using Application.Interfaces.IServices;
using Application.Models.DTOs.Region;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RegionService : IRegionService
    {
        public Task<IEnumerable<RegionForListDto>> GetAllRegion()
        {
            throw new NotImplementedException();
        }

        public Task<RegionForDetailDto> GetRegionById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> Insert(RegionForInsertDto regionForInsertDto)
        {
            throw new NotImplementedException();
        }
    }
}
