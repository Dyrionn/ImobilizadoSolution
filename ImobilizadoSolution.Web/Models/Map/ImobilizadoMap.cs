using ImobilizadoSolution.Domain;
using ImobilizadoSolution.Web.Models.DTO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImobilizadoSolution.Web.Models.Map
{
    public class ImobilizadoMap : IBaseMap<Imobilizado, ImobilizadoDTO>
    {
        public List<Imobilizado> Mapper(List<ImobilizadoDTO> targets)
        {
            throw new NotImplementedException();
        }

        public List<ImobilizadoDTO> Mapper(List<Imobilizado> sources)
        {
            List<ImobilizadoDTO>  listaDtoRetorno = sources.Select(x => new ImobilizadoDTO()
            {
                _id = x._id.ToString(),
                Nome = x.Nome,
                DataCadastro = x.DataCadastro,
                Status = x.Status
            }).ToList();

            return listaDtoRetorno;

        }

        public ImobilizadoDTO Mapper(Imobilizado source)
        {
            return new ImobilizadoDTO
            {
                _id = source._id.ToString(),
                Nome = source.Nome,
                DataCadastro = source.DataCadastro,
                Status = source.Status
            };
        }

        public Imobilizado Mapper(ImobilizadoDTO target)
        {
            return new Imobilizado
            {
                _id = ObjectId.Parse(target._id),
                Nome = target.Nome,
                DataCadastro = target.DataCadastro,
                Status = target.Status
            };
        }
    }
}