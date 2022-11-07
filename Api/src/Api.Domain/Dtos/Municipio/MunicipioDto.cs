﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Municipio
{
    public class MunicipioDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Nome de Município é campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome de Município deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Código do EBGE inválido")]
        public int CodIBGE { get; set; }
        [Required(ErrorMessage = "Código de UF é campo obrigatório")]
        public Guid UfId { get; set; }
    }
}
