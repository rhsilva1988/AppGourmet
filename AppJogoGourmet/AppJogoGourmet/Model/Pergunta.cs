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
    public class Pergunta : No
    {
        private readonly IComponenteInterfaceUsuario _componenteInterface;

        public Pergunta(IComponenteInterfaceUsuario componenteInterface, No esquerda, No direita, string nomePrato) : base(esquerda, direita, nomePrato)
        {
            _componenteInterface = componenteInterface;
        }

        public override RespostaEnum GetResposta()
        {
            var mensagemPergunta = $"O prato que você pensou {NomePrato}?";
            return _componenteInterface.GetResposta(mensagemPergunta);
        }

        public override void ProximoNo(RespostaEnum ultimaOpcao, No noParente)
        {
            var answer = GetResposta();

            if (answer == RespostaEnum.Yes)
            {
                NoFilhoDireita.ProximoNo(answer, this);
            }
            else
            {
                NoFilhoEsquerda.ProximoNo(answer, this);
            }
        }
    }
}
