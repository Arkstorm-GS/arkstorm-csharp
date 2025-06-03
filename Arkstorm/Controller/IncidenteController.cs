using Oracle.ManagedDataAccess.Client;
using Arkstorm.Model;

namespace Arkstorm.Controller
{
    public class IncidenteController
    {
        private readonly string conn = "User Id=RM550826;Password=230401;Data Source=oracle.fiap.com.br:1521/ORCL";

        public void Inserir(Incidente i)
        {
            using var con = new OracleConnection(conn);
            con.Open();
            var cmd = new OracleCommand("INSERT INTO INCIDENTES_ARC (TIPO, DESCRICAO, IMPACTO, DATAHORA) VALUES (:t, :d, :i, :dt)", con);
            cmd.Parameters.Add("t", i.Tipo);
            cmd.Parameters.Add("d", i.Descricao);
            cmd.Parameters.Add("i", i.Impacto);
            cmd.Parameters.Add("dt", i.DataHora);
            cmd.ExecuteNonQuery();
        }

        public List<Incidente> Listar()
        {
            var lista = new List<Incidente>();
            using var con = new OracleConnection(conn);
            con.Open();
            var cmd = new OracleCommand("SELECT * FROM INCIDENTES_ARC", con);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Incidente
                {
                    Id = reader.GetInt32(0),
                    Tipo = reader.GetString(1),
                    Descricao = reader.GetString(2),
                    Impacto = reader.GetString(3),
                    DataHora = reader.GetDateTime(4)
                });
            }
            return lista;
        }
    }
}