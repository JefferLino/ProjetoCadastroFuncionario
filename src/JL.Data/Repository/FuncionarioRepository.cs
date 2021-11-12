using JL.Business.Intefaces.Repository;
using JL.Business.Models.Funcionarios;
using JL.Data.Context;

namespace JL.Data.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(CadastroFuncionarioContext context) : base(context) { }
    }
}
