using Domain.Dtos.Municipio;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Cep
{
    public class CepDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="CEP é um campo obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Logradouro é um campo obrigatório")]
        public string Logradouro { get; set; }

        public string Numero { get; set; }
        [Required(ErrorMessage = "Município é um campo obrigatório")]

        public Guid MunicipioId { get; set; }

        public MunicipioCompletoDto Municipio { get; set; }
    }
}
