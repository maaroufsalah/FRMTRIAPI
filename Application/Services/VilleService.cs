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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VilleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<VilleForListDto>> GetAllVilles()
        {
            var test = await _unitOfWork.Ville.GetAllAsync();
            IEnumerable<Ville> villes = await _unitOfWork.Ville.GetAllAsync(includes: i => i.Region);
            var mappedVilles = _mapper.Map<IEnumerable<VilleForListDto>>(villes);
            return mappedVilles;
        }

        public async Task<VilleForDetailDto> GetVilleById(int id)
        {
            Ville ville = await _unitOfWork.Ville.FirstOrDefaultAsync(predicate: p => p.Id == id,includes: i => i.Region);
            var mappedVille = _mapper.Map<VilleForDetailDto>(ville);
            return mappedVille;
        }
    }
}
