using ImobilizadoSolution.Domain;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobilizadoSolution.Service.Contract
{
    public interface IImobilizadoService
    {
        bool Adicionar(Imobilizado imobilizado);

        bool Atualizar(Imobilizado imobilizado);

        bool Deletar(ObjectId codigo);

        Task<List<Imobilizado>> Listar();

        Task<Imobilizado> ListarPorCodigo(ObjectId codigo);

    }
}
