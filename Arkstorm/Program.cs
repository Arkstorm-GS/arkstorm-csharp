using Arkstorm.View;
using Arkstorm.Controller;

namespace Arkstorm
{
    class Program
    {
        static void Main()
        {
            var loginView = new LoginView();
            var consoleView = new ConsoleView();
            var loginController = new LoginController();
            var falhaController = new FalhaController();
            var incidenteController = new IncidenteController();
            var equipamentoController = new EquipamentoController();

            bool loginValido = false;

            while (!loginValido)
            {
                var user = loginView.SolicitarLogin();
                loginValido = loginController.ValidarLogin(user);

                if (!loginValido)
                {
                    loginView.MostrarMensagem("Usuário ou senha incorretos. Tente novamente.\n");
                }
            }

            bool rodando = true;
            while (rodando)
            {
                consoleView.ExibirMenu();
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        falhaController.Inserir(consoleView.LerFalha());
                        break;
                    case "2":
                        consoleView.MostrarFalhas(falhaController.Listar());
                        break;
                    case "3":
                        var cidade = consoleView.PerguntarCidadeRelatorio();
                        consoleView.MostrarFalhas(falhaController.BuscarPorCidade(cidade));
                        break;
                    case "4":
                        incidenteController.Inserir(consoleView.LerIncidente());
                        break;
                    case "5":
                        consoleView.MostrarIncidentes(incidenteController.Listar());
                        break;
                    case "6":
                        equipamentoController.Inserir(consoleView.LerEquipamento());
                        break;
                    case "7":
                        consoleView.MostrarEquipamentos(equipamentoController.Listar());
                        break;
                    case "8":
                        rodando = false;
                        break;
                    default:
                        consoleView.MostrarMensagem("Opção inválida.");
                        break;
                }
            }
        }
    }
}