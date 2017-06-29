
using ImobilizadoSolution.Domain;
using ImobilizadoSolution.Service;
using ImobilizadoSolution.Service.Contract;
using ImobilizadoSolution.Service.Implementation;
using ImobilizadoSolution.Web.Controllers;
using ImobilizadoSolution.Web.Models.DTO;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;


namespace ImobilizadoSolution.Test
{
    public class ImobilizadoControllerTest
    {
        [Fact]
        public void ListarPorCodigo_ImobilizadoListarPorCodigo_Sucesso()
        {
            //var servico = new Mock<IImobilizadoService>();
            //var imobilizado = new Task<Imobilizado>(() => Console.Write("ok"));
            //servico
            //    .Setup(x => x.ListarPorCodigo(It.IsAny<ObjectId>()))
            //    .Returns(imobilizado);

            ////act
            //ImobilizadoController classeTeste = new ImobilizadoController();
            //var result = classeTeste.ListarPorCodigo(ObjectId.GenerateNewId().ToString());

            ////result.
            //Assert.True(result.Result.IsSuccessStatusCode);
        }

        [Fact]
        public void ListarPorCodigo_ImobilizadoListar_Sucesso()
        {
            //arrange
            var servico = new Mock<IImobilizadoService>();
            servico
                .Setup(x => x.Listar())
                .Returns(It.IsAny<Task<List<Imobilizado>>>);

            //act
            ImobilizadoController classeTeste = new ImobilizadoController();
            var result = classeTeste.Listar();

            //result.
            Assert.True(result.Result.IsSuccessStatusCode);
        }

        [Fact]
        public void Adicionar_ImobilizadoAdicionado_Sucesso()
        {
            //arrange
            var servico = new Mock<IImobilizadoService>();
            ImobilizadoDTO imobilizado = new ImobilizadoDTO();
            servico
                .Setup(x => x.Adicionar(It.IsAny<Imobilizado>()))
                .Returns(true);

            //act
            ImobilizadoController classeTeste = new ImobilizadoController();
            var result = classeTeste.Adicionar(imobilizado);

            //result.
            Assert.True(result.IsSuccessStatusCode);
        }

        [Fact]
        public void Alterar_UsuarioAlterado_Sucesso()
        {
            var servico = new Mock<IImobilizadoService>();
            servico
                .Setup(x => x.Atualizar(It.IsAny<Imobilizado>()))
                .Returns(true);

            //act
            ImobilizadoController classeTeste = new ImobilizadoController();
            var result = classeTeste.Atualizar(It.IsAny<ImobilizadoDTO>());

            //result.
            Assert.True(result.IsSuccessStatusCode);
        }

        [Fact]
        public void Deletar_UsuarioDeletado_Sucesso()
        {
            //arrange
            var servico = new Mock<IImobilizadoService>();
            servico
                .Setup(x => x.Deletar(ObjectId.GenerateNewId()))
                .Returns(true);

            //act
            ImobilizadoController classeTeste = new ImobilizadoController();
            var result = classeTeste.Deletar(ObjectId.GenerateNewId().ToString());

            //result.
            Assert.True(result.IsSuccessStatusCode);
        }

    }
}
