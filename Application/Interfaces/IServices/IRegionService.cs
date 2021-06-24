using Application.Models.DTOs.Region;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
     public interface IRegionService
    {
        Task<IEnumerable<RegionForListDto>> GetAllRegion();
        Task<RegionForDetailDto> GetRegionById(int id);

        Task<Response<bool>> Insert(RegionForInsertDto regionForInsertDto) ;
    }
}
