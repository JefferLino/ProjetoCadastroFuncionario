using AutoMapper;
using Jl.Testes.Services;
using JL.Api.Controllers;
using JL.Business.Intefaces.Notificacoes;
using JL.Business.Intefaces.Service;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Jl.Testes.Controllers
{
    public class FuncionariosControllerTest
    {
        IFuncionarioService _funcionarioService;
        FuncionariosController _funcionariosController;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;

        public FuncionariosControllerTest()
        {
            _funcionariosController = new FuncionariosController(_funcionarioService, _mapper, _notificador);
            _funcionarioService = new FuncionarioServiceFake();
        }

        [Fact]
        public void Get_ObterTodos()
        {
            var resultado = _funcionariosController.ObterTodos();
            Assert.IsType<OkObjectResult>(resultado.Result);
        }
    }
}
