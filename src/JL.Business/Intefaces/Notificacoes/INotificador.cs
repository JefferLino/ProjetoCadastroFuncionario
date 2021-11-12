using JL.Business.Notificacoes;
using System.Collections.Generic;

namespace JL.Business.Intefaces.Notificacoes
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
