using System;

namespace JL.Business.Models.Funcionarios
{
    public class Funcionario : EntidadeBase
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public string NumeroChapa { get; set; }

        public string Senha { get; set; }
    }
}
