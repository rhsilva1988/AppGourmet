using AppJogoGourmet.Model.Enumeraveis;

namespace AppJogoGourmet.Model.Base
{
    public abstract class No
    {
        public No NoFilhoEsquerda { get; set; }

        public No NoFilhoDireita { get; set; }

        public string NomePrato { get; set; }

        protected No(No esquerda, No direita, string nomePrato)
        {
            NoFilhoEsquerda = esquerda;
            NoFilhoDireita = direita;
            NomePrato = nomePrato;
        }

        public abstract RespostaEnum GetResposta();

        public abstract void ProximoNo(RespostaEnum ultimaOpcao, No noParente);
    }
}
