using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobilizadoSolution.Domain
{
    [Table(nameof(Imobilizado))]
    public class Imobilizado
    {
        public ObjectId _id { get; set; }
        public string Nome { get; set; }
        public string DataCadastro { get; set; }
        public bool Status { get; set; }
    }
}
