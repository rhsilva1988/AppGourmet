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
    public class Jogo : No
    {
        private readonly IComponenteInterfaceUsuario _componenteInterface;

        public Jogo(IComponenteInterfaceUsuario interfaceComponenteInterface, No esquerda, No direita, string nomePrato) : base(esquerda, direita, nomePrato)
        {
            _componenteInterface = interfaceComponenteInterface;
        }

        public override RespostaEnum GetResposta()
        {
            var mensagemPergunta = $"O prato que você pensou é {NomePrato}?";
            return _componenteInterface.GetResposta(mensagemPergunta);
        }

        public override void ProximoNo(RespostaEnum ultimaOpcao, No noParente)
        {
            var answer = GetResposta();

            if (answer == RespostaEnum.Yes)
            {
                _componenteInterface.ShowSucesso();
            }
            else
            {
                MontarProximoTurno(ultimaOpcao, noParente);
            }
        }

        private void MontarProximoTurno(RespostaEnum ultimaOpcao, No noParente)
        {
            var novoTurno = Turno.Instance;
            novoTurno.MontarTurno(_componenteInterface, this, ultimaOpcao, noParente);
        }
    }
}
