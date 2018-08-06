using AppJogoGourmet.Model.Enumeraveis;

namespace AppJogoGourmet.Model.Interface
{
    public interface IComponenteInterfaceUsuario
    {
        void ShowSucesso();
        RespostaEnum GetResposta(string question);
        void ShowMensagem(string message);
        string InputBox(string prompt);
    }
}
