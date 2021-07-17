using System.Collections.Generic;

namespace Confitec.Core.Messages
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);        
    }
}
