using Domain.Dtos.Municipio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Municipio
{
    public interface IMunicipioService
    {
        Task<MunicipioDto> Get(Guid id);
        Task<MunicipioCompletoDto> GetCompletById(Guid id);
        Task<MunicipioCompletoDto> GetCompleteByIBGE(int codIBGE);
        Task<IEnumerable<MunicipioDto>> GetAll();
        Task<MunicipioDtoResult> Post(MunicipioDto municipio);
        Task<MunicipioDtoResult> Put(MunicipioDto municipio);
        Task<bool> Delete(Guid id);
    }
}
