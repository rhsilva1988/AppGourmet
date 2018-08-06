using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppJogoGourmet.Model.Base;
using AppJogoGourmet.Model.Enumeraveis;
using AppJogoGourmet.Model.Interface;

namespace AppJogoGourmet.Model
{
    public class Turno
    {
        private static readonly Lazy<Turno> Lazy =
            new Lazy<Turno>(() => new Turno());

        public static Turno Instance => Lazy.Value;
        private string Pergunta { get; }
        private string MensagemErro { get; }

        private Turno()
        {
            Pergunta = "Qual o prato que você pensou?";
            MensagemErro = "Dados do novo prato não informados!";
        }

        public void MontarTurno(IComponenteInterfaceUsuario componenteInterface, No noSelecionado, RespostaEnum ultimaOpcao, No noParente)
        {
            if (ChecarValoresProximoTurno(componenteInterface, noSelecionado, out var resposta, out var acao))
                return;

            var jogo = new Jogo(componenteInterface, null, null, resposta);

            if (ultimaOpcao == RespostaEnum.Yes)
                noParente.NoFilhoDireita = new Pergunta(componenteInterface, noSelecionado, jogo, acao);
            else
                noParente.NoFilhoEsquerda = new Pergunta(componenteInterface, noSelecionado, jogo, acao);
        }

        private bool ChecarValoresProximoTurno(IComponenteInterfaceUsuario componenteInterface, No noSelecionado,
            out string resposta, out string acao)
        {
            resposta = componenteInterface.InputBox(Pergunta);
            acao = componenteInterface.InputBox($"{resposta} é _____ mas {noSelecionado.NomePrato} não.");

            if (!string.IsNullOrWhiteSpace(acao) && !string.IsNullOrWhiteSpace(resposta))
                return false;

            componenteInterface.ShowMensagem(MensagemErro);
            return true;
        }
    }
}
