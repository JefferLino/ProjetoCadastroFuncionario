using JL.Business.Intefaces.Notificacoes;
using JL.Business.Intefaces.Repository;
using JL.Business.Intefaces.Service;
using JL.Business.Models.Funcionarios;
using JL.Business.Models.Validations;
using JL.Business.Services.Base;
using JL.Infra.Utilitarios.Cripotografia;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JL.Business.Services.Funcionarios
{
    public class FuncionarioService : BaseService, IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository, INotificador notificador) : base(notificador)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<bool> Adicionar(Funcionario funcionario)
        {
            if (!ExecutarValidacao(new FuncionarioValidation(), funcionario)) return false;

            await _funcionarioRepository.Adicionar(funcionario);
            return true;
        }

        public async Task<bool> Atualizar(Funcionario funcionario)
        {
            if (!ExecutarValidacao(new FuncionarioValidation(), funcionario)) return false;

            ObtenhaSenhaUsuario(funcionario);

            await _funcionarioRepository.Atualizar(funcionario);
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _funcionarioRepository.Remover(id);
            return true;
        }

        public async Task<Funcionario> ObterPorId(int id)
        {
            return await _funcionarioRepository.ObterPorId(id);
        }

        public async Task<List<Funcionario>> ObterTodos()
        {
            return await _funcionarioRepository.ObterTodos();
        }

        public void Dispose()
        {
            _funcionarioRepository?.Dispose();
        }

        private void ObtenhaSenhaUsuario(Funcionario funcionario)
        {
            if (!string.IsNullOrEmpty(funcionario.Senha))
                funcionario.Senha = CriptografiaDeValores.CalculaHash(funcionario.Senha);
        }
    }
}
