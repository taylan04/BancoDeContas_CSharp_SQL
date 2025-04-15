using Microsoft.Data.SqlClient;
using Banco_.Models;

namespace Banco_ {
    internal class CrudDb {

        const string connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Banco;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public static void IncluirContaDb(string nome, double saldo) {
            string sql = "insert into conta (nome, saldo) values (@nome, @saldo)";
            
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@nome", nome));
                    cmd.Parameters.Add(new SqlParameter("@saldo", saldo));
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void AlterarContaDb(Conta conta) { 
            string sql = "update conta set saldo = @saldo where id = @id";

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@saldo", conta.Saldo));
                    cmd.Parameters.Add(new SqlParameter("@id", conta.Id));
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void ExcluirContaDb(int id) {
            string sql = "delete from conta where id = @id";
            
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static Conta ConsultarContaDb(int id) {
            string sql = "select * from conta where id = @id";
            Conta conta = null;

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read()) {
                        int idConta = int.Parse(dr["id"].ToString());
                        string nome = dr["nome"].ToString();
                        double saldo = double.Parse(dr["saldo"].ToString());
                        conta = new Conta(idConta, nome, saldo);
                    }
                }
                catch (SqlException ex) {
                    Console.WriteLine(ex.Message);
                }
            }
            return conta;
        }

        public static List<Conta> ConsultarContasDb() {
            var contas = new List<Conta>();
            string sql = "select * from conta";

            using (var conn = new SqlConnection(connectionString)) {
                try {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        int id = int.Parse(dr["id"].ToString());
                        string nome = dr["nome"].ToString();
                        double saldo = double.Parse(dr["saldo"].ToString());
                        Conta conta = new Conta(id, nome, saldo);
                        contas.Add(conta);
                    }
                }
                catch (SqlException ex) {
                    Console.WriteLine(ex);
                }
            }
            return contas;
        }
    }
}
