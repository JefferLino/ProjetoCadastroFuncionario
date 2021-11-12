using AutoMapper;
using JL.Api.ViewModels;
using JL.Business.Intefaces.Notificacoes;
using JL.Business.Intefaces.Service;
using JL.Business.Models.Funcionarios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JL.Api.Controllers
{
    [Route("api/funcionarios")]
    [ApiController]
    public class FuncionariosController : BaseController
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IMapper _mapper;

        public FuncionariosController(IFuncionarioService funcionarioService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _funcionarioService = funcionarioService;
            _mapper = mapper;
        }


        /// <summary>
        /// Realiza a adição do funcionário no banco de dados.
        /// </summary>
        /// <param name="funcionarioViewModel">O usuário.</param>
        /// <returns>O resultado da adição.</returns>
        [HttpPost]
        public async Task<ActionResult<FuncionarioViewModel>> Adicionar(FuncionarioViewModel funcionarioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _funcionarioService.Adicionar(_mapper.Map<Funcionario>(funcionarioViewModel));

            return CustomResponse(funcionarioViewModel);
        }

        /// <summary>
        /// Realiza a atualização do usuário no banco de dados.
        /// </summary>
        /// <param name="funcionarioViewModel">O funcionário.</param>
        /// <returns>O resultado da adição.</returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<FuncionarioViewModel>> Atualizar(int id, FuncionarioViewModel funcionarioViewModel)
        {
            if (id != funcionarioViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo do usuário desejado");
                return CustomResponse(funcionarioViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _funcionarioService.Atualizar(_mapper.Map<Funcionario>(funcionarioViewModel));

            return CustomResponse(funcionarioViewModel);
        }

        /// <summary>
        /// Realiza a exclusão do funcionário.
        /// </summary>
        /// <param name="id">O id do funcionário.</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<FuncionarioViewModel>> Excluir(int id)
        {
            var funcionarioViewModel = await _funcionarioService.ObterPorId(id);

            if (funcionarioViewModel == null) return NotFound();

            await _funcionarioService.Remover(id);

            return CustomResponse(funcionarioViewModel);
        }

        /// <summary>
        /// Obtenha todos os funcionários.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<FuncionarioViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<FuncionarioViewModel>>(await _funcionarioService.ObterTodos());
        }

        /// <summary>
        /// Obtém o funcionário pelo id.
        /// </summary>
        /// <param name="id">O id do funcionário.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FuncionarioViewModel>> ObterPorId(int id)
        {
            Funcionario funcionario = await ObtenhafuncionarioPorId(id);

            if (funcionario == null) return NotFound();

            return _mapper.Map<FuncionarioViewModel>(funcionario);
        }

        private async Task<Funcionario> ObtenhafuncionarioPorId(int id)
        {
            return await _funcionarioService.ObterPorId(id);
        }
    }
}
