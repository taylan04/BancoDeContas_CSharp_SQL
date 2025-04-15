using static Banco_.CrudDb;
using static Banco_.Util;

namespace Banco_ {
    public class Crud {

        public static void IncluirConta() {
            string nome = EntrarNome();
            double saldo = EntrarSaldo();
            IncluirContaDb(nome, saldo);
        }

        public static void AlterarConta() {
            int id = EntrarId();
            var conta = ConsultarContaDb(id);
            if (conta == null) {
                Console.WriteLine("\nEssa conta não existe!");
                return;
            }
            conta.Creditar(100);
            AlterarContaDb(conta);
        }

        public static void ExcluirConta() {
            int id = EntrarId();
            var conta = ConsultarContaDb(id);
            if (conta == null) {
                Console.WriteLine("\nEssa conta não existe!");
                return;
            }
            ExcluirContaDb(id);
        }

        public static void ConsultarConta() {
            int id = EntrarId();
            var conta = ConsultarContaDb(id);
            if (conta == null) {
                Console.WriteLine("\nEssa conta não existe!");
                return;
            }
            Console.WriteLine(conta);
        }

        public static void ConsultarContas() {
            var contas = ConsultarContasDb();
            if (contas == null) {
                Console.WriteLine("\nO banco de dados está vazio!");
                return;
            }
            foreach (var conta in contas) {
                Console.WriteLine(conta);
            }
        }
    }
}
