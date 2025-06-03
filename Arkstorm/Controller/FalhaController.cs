using Oracle.ManagedDataAccess.Client;
using Arkstorm.Model;

namespace Arkstorm.Controller
{
    public class FalhaController
    {
        private readonly string conn = "User Id=RM550826;Password=230401;Data Source=oracle.fiap.com.br:1521/ORCL";

        public void Inserir(FalhaEnergia f)
        {
            using var con = new OracleConnection(conn);
            con.Open();
            var cmd = new OracleCommand("INSERT INTO FALHAS_ARC (CIDADE, DESCRICAO, RISCO, DATAHORA) VALUES (:c, :d, :r, :dt)", con);
            cmd.Parameters.Add("c", f.Cidade);
            cmd.Parameters.Add("d", f.Descricao);
            cmd.Parameters.Add("r", f.Risco);
            cmd.Parameters.Add("dt", f.DataHora);
            cmd.ExecuteNonQuery();
        }

        public List<FalhaEnergia> Listar()
        {
            var lista = new List<FalhaEnergia>();
            using var con = new OracleConnection(conn);
            con.Open();
            var cmd = new OracleCommand("SELECT * FROM FALHAS_ARC ORDER BY DATAHORA DESC", con);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new FalhaEnergia
                {
                    Id = reader.GetInt32(0),
                    Cidade = reader.GetString(1),
                    Descricao = reader.GetString(2),
                    Risco = reader.GetString(3),
                    DataHora = reader.GetDateTime(4)
                });
            }
            return lista;
        }

        public List<FalhaEnergia> BuscarPorCidade(string cidade)
        {
            var lista = new List<FalhaEnergia>();
            using var con = new OracleConnection(conn);
            con.Open();
            var cmd = new OracleCommand("SELECT * FROM FALHAS_ARC WHERE CIDADE = :c", con);
            cmd.Parameters.Add("c", cidade);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new FalhaEnergia
                {
                    Id = reader.GetInt32(0),
                    Cidade = reader.GetString(1),
                    Descricao = reader.GetString(2),
                    Risco = reader.GetString(3),
                    DataHora = reader.GetDateTime(4)
                });
            }
            return lista;
        }
    }
}