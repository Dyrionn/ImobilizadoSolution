using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImobilizadoSolution.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void Adicionar(T entity);

        void Atualizar(T entity, ObjectId codigo);

        void Deletar(ObjectId codigo);

        Task<List<T>> Listar();

        Task<T> ListarPorCodigo(ObjectId codigo);
    }
}
