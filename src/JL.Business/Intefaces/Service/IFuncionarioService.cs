using JL.Business.Models.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JL.Business.Intefaces.Service
{
    public interface IFuncionarioService: IDisposable
    {
        Task<bool> Adicionar(Funcionario funcionario);
        Task<bool> Atualizar(Funcionario funcionario);
        Task<bool> Remover(int id);
        Task<Funcionario> ObterPorId(int id);
        Task<List<Funcionario>> ObterTodos();
    }
}
