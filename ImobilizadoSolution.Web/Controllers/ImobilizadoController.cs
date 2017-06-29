using ImobilizadoSolution.Service.Contract;
using ImobilizadoSolution.Service.Implementation;
using ImobilizadoSolution.Web.Models.DTO;
using ImobilizadoSolution.Web.Models.Map;
using MongoDB.Bson;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ImobilizadoSolution.Web.Controllers
{
    public class ImobilizadoController : ApiController
    {
        private static ImobilizadoMap mapper;
        private IImobilizadoService _service;

        public ImobilizadoController()
        {
            mapper = new ImobilizadoMap();
            _service = new ImobilizadoService();
        }

        [HttpGet]
        [Route("api/imobilizado/listarporcodigo/{codigo}")]
        public async Task<HttpResponseMessage> ListarPorCodigo(string codigo)
        {
            var result = await _service.ListarPorCodigo(ObjectId.Parse(codigo));

            return Request.CreateResponse(HttpStatusCode.OK, mapper.Mapper(result));
        }

        [HttpGet]
        [Route("api/imobilizado/listar")]
        public async Task<HttpResponseMessage> Listar()
        {
            var result = await _service.Listar();

            return Request.CreateResponse(HttpStatusCode.OK, mapper.Mapper(result));
        }

        [HttpPost]
        [Route("api/imobilizado/cadastrar")]
        public HttpResponseMessage Adicionar(ImobilizadoDTO imobilizado)
        {

            imobilizado.DataCadastro = DateTime.Now.ToString("yyyyMMdd");
            imobilizado._id = ObjectId.GenerateNewId().ToString();

            if (_service.Adicionar(mapper.Mapper(imobilizado)))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Cadastro realizado com sucesso.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao realizar o cadastro.");
            }
        }

        [HttpPost]
        [Route("api/imobilizado/alterar")]
        public HttpResponseMessage Atualizar(ImobilizadoDTO imobilizado)
        {
            
            if (_service.Atualizar(mapper.Mapper(imobilizado)))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Alteração realizada com sucesso.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao realizar a alteração.");
            }
                
        }

        [HttpDelete]
        [Route("api/imobilizado/excluir/{codigo}")]
        public HttpResponseMessage Deletar(string codigo)
        {
            if (_service.Deletar(ObjectId.Parse(codigo)))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Exclusão realizada com sucesso.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Falha ao realizar a exclusão.");
            }
        }

    }
}
