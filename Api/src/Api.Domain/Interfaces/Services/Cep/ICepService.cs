using Domain.Dtos.Cep;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Cep
{
    public interface ICepService
    {
        Task<CepDto> Get(Guid id);
        Task<CepDto> Get(string cep);
        Task<CepDtoResult> Post(CepDto cep);
        Task<CepDtoResult> Put(CepDto cep);
        Task<bool> Delete(Guid id);
    }
}
