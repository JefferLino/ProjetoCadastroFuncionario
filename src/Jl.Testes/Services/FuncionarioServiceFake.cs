using JL.Business.Intefaces.Service;
using JL.Business.Models.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jl.Testes.Services
{
    public class FuncionarioServiceFake : IFuncionarioService
    {
        private readonly List<Funcionario> _funcionarios;

        public FuncionarioServiceFake()
        {
            _funcionarios = new List<Funcionario>()
            {
                new Funcionario() { Id = 1, Nome = "TESTE NOME 1", Sobrenome ="TESTE SOBRENOME 1", Email = "email1@gmail.com" },
                new Funcionario() { Id = 2, Nome = "TESTE NOME 2", Sobrenome ="TESTE SOBRENOME 2", Email = "email2@gmail.com" },
                new Funcionario() { Id = 3, Nome = "TESTE NOME 3", Sobrenome ="TESTE SOBRENOME 3", Email = "email3@gmail.com" },
                new Funcionario() { Id = 4, Nome = "TESTE NOME 4", Sobrenome ="TESTE SOBRENOME 4", Email = "email4@gmail.com" },
                new Funcionario() { Id = 5, Nome = "TESTE NOME 5", Sobrenome ="TESTE SOBRENOME 5", Email = "email5@gmail.com" }
            };
        }

        public Task<bool> Adicionar(Funcionario funcionario)
        {
            _funcionarios.Add(funcionario);

            return Task.FromResult(true);
        }

        public Task<bool> Atualizar(Funcionario funcionario)
        {
            Remover(funcionario.Id);

            _funcionarios.Add(funcionario);

            return Task.FromResult(true);
        }

        public Task<Funcionario> ObterPorId(int id)
        {
           return Task.FromResult(_funcionarios.Where(a => a.Id == id).FirstOrDefault());
        }

        public Task<List<Funcionario>> ObterTodos()
        {
            return Task.FromResult(_funcionarios);
        }

        public Task<bool> Remover(int id)
        {
           var func = _funcionarios.Where(f => f.Id == id).FirstOrDefault();
           
           if(func !=null)
             _funcionarios.RemoveAll(f => f.Id == func.Id);

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
