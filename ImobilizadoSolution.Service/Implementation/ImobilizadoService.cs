using ImobilizadoSolution.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImobilizadoSolution.Domain;
using MongoDB.Bson;
using ImobilizadoSolution.Repository.Implementation;
using ImobilizadoSolution.Repository;
using ImobilizadoSolution.Repository.Contract;

namespace ImobilizadoSolution.Service.Implementation
{
    public class ImobilizadoService : BaseService, IImobilizadoService
    {

        private IImobilizadoRepository repositorio;

        public ImobilizadoService()
        {
            repositorio = new ImobilizadoRepository(nameof(Imobilizado));
        }

        public bool Adicionar(Imobilizado imobilizado)
        {
            try
            {
                repositorio.Adicionar(imobilizado);
            }
            catch (Exception)
            {
                ErrorList.Add("Falha ao adicionar o registro");
            }

            return ListarPorCodigo(imobilizado._id) != null;
        }

        public bool Atualizar(Imobilizado imobilizado)
        {
            //REGRA, se não encontrar, não altera
            try
            {
                if (repositorio.ListarPorCodigo(imobilizado._id) != null)
                {
                    repositorio.Atualizar(imobilizado, imobilizado._id);
                }
                else
                {
                    ErrorList.Add("Registro não encontrado");
                }
            }
            catch (Exception)
            {
                ErrorList.Add("Falha ao atualizar o registro");
            }
            return repositorio.ListarPorCodigo(imobilizado._id).Result == imobilizado;
        }

        public bool Deletar(ObjectId codigo)
        {
            //REGRA, se estiver ativo não deleta
            try
            {
                var imobilizado = repositorio.ListarPorCodigo(codigo);

                if (imobilizado.IsCompleted)
                {
                    repositorio.Deletar(codigo);
                }
                else
                {
                    ErrorList.Add("Não é possível deletar um registro ativo");
                }
            }
            catch (Exception)
            {
                ErrorList.Add("Falha ao deletar o registro");
            }
            return ListarPorCodigo(codigo) == null;
        }

        public async Task<List<Imobilizado>> Listar()
        {
            return await repositorio.Listar();
        }

        public async Task<Imobilizado> ListarPorCodigo(ObjectId codigo)
        {
            return await repositorio.ListarPorCodigo(codigo);
        }

    }
}
