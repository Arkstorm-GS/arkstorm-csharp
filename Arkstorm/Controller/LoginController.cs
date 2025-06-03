using Oracle.ManagedDataAccess.Client;
using Arkstorm.Model;

namespace Arkstorm.Controller
{
    public class LoginController
    {
        private readonly string conn = "User Id=RM550826;Password=230401;Data Source=oracle.fiap.com.br:1521/ORCL";

        public bool ValidarLogin(Usuario user)
        {
            using var con = new OracleConnection(conn);
            con.Open();
            var cmd = new OracleCommand("SELECT COUNT(*) FROM USUARIOS WHERE USERNAME = :u AND SENHA = :s", con);
            cmd.Parameters.Add("u", user.Username);
            cmd.Parameters.Add("s", user.Senha);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count == 1;
        }
    }
}