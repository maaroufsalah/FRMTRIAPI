using Application.Models.DTOs.Ville;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IVilleService : IDisposable
    {
        Task<IEnumerable<VilleForListDto>> GetAllVilles();
        Task<VilleForDetailDto> GetVilleById(int id);
        Task<Response<bool>> Insert(VilleForInsertDto villeForInsertDto);
        Task<Response<bool>> Update(VilleForUpdateDto villeForUpdateDto);
    }
}
