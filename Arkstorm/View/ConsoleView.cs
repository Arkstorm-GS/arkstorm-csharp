using Arkstorm.Model;

namespace Arkstorm.View
{
    public class ConsoleView
    {
        public void ExibirMenu()
        {
            Console.WriteLine("\n==== ARKSTORM MENU ====");
            Console.WriteLine("1 - Registrar Falha Energética");
            Console.WriteLine("2 - Listar Falhas");
            Console.WriteLine("3 - Relatório por Cidade");
            Console.WriteLine("4 - Registrar Incidente Cibernético");
            Console.WriteLine("5 - Listar Incidentes");
            Console.WriteLine("6 - Cadastrar Equipamento Crítico");
            Console.WriteLine("7 - Listar Equipamentos");
            Console.WriteLine("8 - Sair");
        }

        public FalhaEnergia LerFalha()
        {
            Console.WriteLine("\n== Registrar Falha Energética ==");
            Console.Write("Cidade: ");
            string cidade = Console.ReadLine();
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("Risco (Alto, Médio, Baixo): ");
            string risco = Console.ReadLine();

            return new FalhaEnergia
            {
                Cidade = cidade,
                Descricao = descricao,
                Risco = risco,
                DataHora = DateTime.Now
            };
        }

        public Incidente LerIncidente()
        {
            Console.WriteLine("\n== Registrar Incidente Cibernético ==");
            Console.Write("Tipo: ");
            string tipo = Console.ReadLine();
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("Impacto: ");
            string impacto = Console.ReadLine();

            return new Incidente
            {
                Tipo = tipo,
                Descricao = descricao,
                Impacto = impacto,
                DataHora = DateTime.Now
            };
        }

        public Equipamento LerEquipamento()
        {
            Console.WriteLine("\n== Cadastrar Equipamento Crítico ==");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Localização: ");
            string local = Console.ReadLine();
            Console.Write("Impacto: ");
            string impacto = Console.ReadLine();

            return new Equipamento
            {
                Nome = nome,
                Localizacao = local,
                Impacto = impacto,
                DataHoraRegistro = DateTime.Now
            };
        }

        public void MostrarFalhas(List<FalhaEnergia> falhas)
        {
            Console.WriteLine("\n== Falhas Registradas ==");
            foreach (var f in falhas)
                Console.WriteLine($"#{f.Id} | {f.Cidade} | {f.Descricao} | {f.Risco} | {f.DataHora}");
        }

        public void MostrarIncidentes(List<Incidente> incidentes)
        {
            Console.WriteLine("\n== Incidentes Cibernéticos ==");
            foreach (var i in incidentes)
                Console.WriteLine($"#{i.Id} | {i.Tipo} | {i.Descricao} | {i.Impacto} | {i.DataHora}");
        }

        public void MostrarEquipamentos(List<Equipamento> eqs)
        {
            Console.WriteLine("\n== Equipamentos Críticos ==");
            foreach (var e in eqs)
                Console.WriteLine($"#{e.Id} | {e.Nome} | {e.Localizacao} | {e.Impacto} | {e.DataHoraRegistro}");
        }

        public string PerguntarCidadeRelatorio()
        {
            Console.Write("\nDigite a cidade para o relatório: ");
            return Console.ReadLine();
        }

        public void MostrarMensagem(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}