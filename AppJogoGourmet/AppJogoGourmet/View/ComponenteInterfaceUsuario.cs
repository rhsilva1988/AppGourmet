using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppJogoGourmet.Model.Enumeraveis;
using AppJogoGourmet.Model.Interface;
using AppJogoGourmet.Properties;
using SimpleInjector;

namespace AppJogoGourmet.View
{
    internal class ComponenteInterfaceUsuario : Form, IComponenteInterfaceUsuario
    {
        private readonly Container _container;
        public ComponenteInterfaceUsuario()
        {
            _container = new Container();
        }
        public void ShowMensagem(string message)
        {
            MessageBox.Show(message, Resources.Titulo_Jogo);
        }

        public void ShowSucesso()
        {
            ShowMensagem(Resources.Show_Sucesso);
        }

        public RespostaEnum GetResposta(string mensagemPergunta)
        {
            return (RespostaEnum)MessageBox.Show(mensagemPergunta, Resources.Titulo_Jogo, MessageBoxButtons.YesNo);
        }

        public string InputBox(string prompt)
        {
            var inputBox = _container.GetInstance<InputBoxDialog>();
            return inputBox.Show(Resources.Titulo_Jogo, prompt);
        }
    }
}
