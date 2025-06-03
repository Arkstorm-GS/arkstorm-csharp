using Arkstorm.Model;

namespace Arkstorm.View
{
    public class LoginView
    {
        public Usuario SolicitarLogin()
        {
            Console.WriteLine("=== LOGIN ===");
            Console.Write("Usuário: ");
            string user = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();
            return new Usuario { Username = user, Senha = senha };
        }

        public void MostrarMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }
}