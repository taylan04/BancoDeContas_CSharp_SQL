using static Banco_.Crud;

namespace Banco {
    internal class Program {
        static void Main(string[] args) {

            //CRUD - create, reader, uptade, delete
            ConsultarContas();
            AlterarConta();
            ConsultarContas();
            //ExcluirConta();
            //ConsultarConta();
        }
    }
}
