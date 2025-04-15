
namespace Banco_ {
    public class Util {

        public static int EntrarInteiro(string msg) {
            int num = 0;

            do {
                try {
                    Console.WriteLine(msg);
                    num = int.Parse(Console.ReadLine());
                    break;
                }
                catch {
                    Console.WriteLine("Erro: valor inválido.");
                }
            } while(true);
            return num;  
        }

        public static int EntrarId() {
            int id = 0;

            do {
                id = EntrarInteiro("\nEntre com o ID da conta: ");
                if (id >= 0) {
                    break;
                } else Console.WriteLine("\nErro: ID inválido.");
            } while (true);
            return id;
        }

        public static string EntrarNome() {  
            Console.WriteLine("\nQual o nome do cliente?");
            string nome = Console.ReadLine();
            return nome;
        }

        public static double EntrarSaldo() {
            Console.WriteLine("\nQual o nome do cliente?");
            double saldo = double.Parse(Console.ReadLine());
            return saldo;
        }
    }
}
