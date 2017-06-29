using ImobilizadoSolution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImobilizadoSolution.Web.Models.DTO
{
    public class ImobilizadoDTO
    {
        public string _id { get; set; }
        public string Nome { get; set; }
        public string DataCadastro { get; set; }
        public bool Status { get; set; }

        public ImobilizadoDTO()
        {

        }
    }
}