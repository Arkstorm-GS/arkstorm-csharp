using Oracle.ManagedDataAccess.Client;
using Arkstorm.Model;

namespace Arkstorm.Controller
{
    public class EquipamentoController
    {
        private readonly string conn = "User Id=RM550826;Password=230401;Data Source=oracle.fiap.com.br:1521/ORCL";

        public void Inserir(Equipamento e)
        {
            using var con = new OracleConnection(conn);
            con.Open();
            var cmd = new OracleCommand("INSERT INTO EQUIPAMENTOS_ARC (NOME, LOCALIZACAO, IMPACTO, DATAHORA_REGISTRO) VALUES (:n, :l, :i, :dt)", con);
            cmd.Parameters.Add("n", e.Nome);
            cmd.Parameters.Add("l", e.Localizacao);
            cmd.Parameters.Add("i", e.Impacto);
            cmd.Parameters.Add("dt", e.DataHoraRegistro);
            cmd.ExecuteNonQuery();
        }

        public List<Equipamento> Listar()
        {
            var lista = new List<Equipamento>();
            using var con = new OracleConnection(conn);
            con.Open();
            var cmd = new OracleCommand("SELECT * FROM EQUIPAMENTOS_ARC", con);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Equipamento
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Localizacao = reader.GetString(2),
                    Impacto = reader.GetString(3),
                    DataHoraRegistro = reader.GetDateTime(4)
                });
            }
            return lista;
        }
    }
}