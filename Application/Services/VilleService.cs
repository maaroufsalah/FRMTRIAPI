using Application.Constants;
using Application.Interfaces.IServices;
using Application.Interfaces.IUnitOfWork;
using Application.Models.DTOs.Ville;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class VilleService : IVilleService
    {
        private bool disposed = false;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VilleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VilleForListDto>> GetAllVilles()
        {
            IEnumerable<Ville> villes = await _unitOfWork.Ville.GetAllAsync(includes: i => i.Region);
            IEnumerable<VilleForListDto> mappedVilles = _mapper.Map<IEnumerable<VilleForListDto>>(villes);
            return mappedVilles;
        }

        public async Task<VilleForDetailDto> GetVilleById(int id)
        {
            Ville ville = await _unitOfWork.Ville.FirstOrDefaultAsync(predicate: p => p.Id == id,includes: i => i.Region);
            var mappedVille = _mapper.Map<VilleForDetailDto>(ville);
            return mappedVille;
        }

        public async Task<Response<bool>> Insert(VilleForInsertDto villeForInsertDto)
        {
            Ville villeMapped = _mapper.Map<Ville>(villeForInsertDto);
            _unitOfWork.Ville.AddAsync(villeMapped);
            await _unitOfWork.CompleteAsync();
            return new Response<bool>(true, ApplicationMessage.InsertSuccess);
        }

        public async Task<Response<bool>> Update(VilleForUpdateDto villeForUpdateDto)
        {
            Ville villeMapped = _mapper.Map<Ville>(villeForUpdateDto);
            _unitOfWork.Ville.UpdateAsync(villeMapped);
            await _unitOfWork.CompleteAsync();
            return new Response<bool>(true, ApplicationMessage.InsertSuccess);
        }

        #region Dispose => Implementing a Dispose method : Microsoft
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                // Free any other managed objects here.
                _unitOfWork.Dispose();
            }
            disposed = true;
        }
        #endregion Dispose => Implementing a Dispose method : Microsoft
    }
}
