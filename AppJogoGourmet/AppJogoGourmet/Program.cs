using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppJogoGourmet.Model;
using AppJogoGourmet.Model.Interface;
using AppJogoGourmet.View;
using SimpleInjector;

namespace AppJogoGourmet
{
    static class Program
    {
        private static Container _container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            Application.Run(_container.GetInstance<InitialView>());
        }

        private static void Bootstrap()
        {
            _container = new Container();

            _container.Register<IComponenteInterfaceUsuario, ComponenteInterfaceUsuario>(Lifestyle.Singleton);
            _container.Register<InputBoxDialog>(Lifestyle.Singleton);
            _container.Register<InitialView>(Lifestyle.Singleton);

            _container.Verify();
        }
    }
}
