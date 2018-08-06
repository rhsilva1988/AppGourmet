using System;
using System.Windows.Forms;
using AppJogoGourmet.Model;
using AppJogoGourmet.Model.Base;
using AppJogoGourmet.Model.Enumeraveis;
using AppJogoGourmet.Model.Interface;
using AppJogoGourmet.Properties;

namespace AppJogoGourmet.View
{
    public partial class InitialView : Form
    {
        private readonly No _root;
        public InitialView(IComponenteInterfaceUsuario componente)
        {
            InitializeComponent();

            _root = new Pergunta(componente, null, null, "é uma massa")
            {
                NoFilhoDireita = new Jogo(componente, null, null, "Lasanha"),
                NoFilhoEsquerda = new Jogo(componente, null, null, "Bolo de Chocolate")
            };
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _root?.ProximoNo(0, null);
        }
    }
}
