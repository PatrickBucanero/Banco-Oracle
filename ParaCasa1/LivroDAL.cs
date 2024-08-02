using System;
using Oracle.ManagedDataAccess.Client;

namespace ParaCasa1
{
    class LivroDAL
    {
        private static String strConexao = "User Id=meu_usuario;Password=minha_senha;Data Source=localhost:1521/xepdb1";
        private static OracleConnection conn = new OracleConnection(strConexao);
        private static OracleCommand strSQL;
        private static OracleDataReader result;

        public static void Conecta()
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Erro.setMsg("Problemas ao se conectar ao Banco de Dados: " + ex.Message);
            }
        }

        public static void Desconecta()
        {
            conn.Close();
        }

        public static void InserirUmLivro(Livro umLivro)
        {
            
            string aux = "INSERT INTO TabLivro(codigo, titulo, autor, editora, ano) VALUES (:codigo, :titulo, :autor, :editora, :ano )";
            strSQL = new OracleCommand(aux, conn);

            strSQL.Parameters.Add(":codigo", umLivro.getCodigo());
            strSQL.Parameters.Add(":titulo", umLivro.getTitulo());
            strSQL.Parameters.Add(":autor", umLivro.getAutor());
            strSQL.Parameters.Add(":editora", umLivro.getEditora());
            strSQL.Parameters.Add(":ano", umLivro.getAno());
            strSQL.ExecuteNonQuery();
        }

        public static void ConsultarUmLivro(Livro umLivro)
        {
            string aux = "SELECT * FROM TabLivro WHERE codigo = :codigo";
            strSQL = new OracleCommand(aux, conn);

            strSQL.Parameters.Add(":codigo", umLivro.getCodigo());
            result = strSQL.ExecuteReader();

            Erro.setErro(false);
            if (result.Read())
            {
                umLivro.setTitulo(result.GetString(1));
                umLivro.setAutor(result.GetString(2));
                umLivro.setEditora(result.GetString(3));
                umLivro.setAno(result.GetString(4));
            }
            else
            {
                Erro.setMsg("Livro não cadastrado.");
            }
        }

        public static bool ExisteLivro(string codigo)
        {
            bool existe = false;
            string query = "SELECT COUNT(*) FROM TabLivro WHERE codigo = :codigo";

            using (OracleCommand command = new OracleCommand(query, conn))
            {
                command.Parameters.Add(":codigo", codigo);
                int count = Convert.ToInt32(command.ExecuteScalar());
                existe = count > 0;
            }

            return existe;
        }

        public static void AlterarUmLivro(Livro umLivro)
        {
            string query = "UPDATE TabLivro SET titulo = :titulo, autor = :autor, editora = :editora, ano = :ano WHERE codigo = :codigo";
            using (OracleCommand command = new OracleCommand(query, conn))
            {
                command.Parameters.Add(":titulo", umLivro.getTitulo());
                command.Parameters.Add(":autor", umLivro.getAutor());
                command.Parameters.Add(":editora", umLivro.getEditora());
                command.Parameters.Add(":ano", umLivro.getAno());
                command.Parameters.Add(":codigo", umLivro.getCodigo());
                command.ExecuteNonQuery();
            }
        }

        public static void ExcluirUmLivro(Livro umLivro)
        {
            string aux = "DELETE FROM TabLivro WHERE codigo = :codigo";
            strSQL = new OracleCommand(aux, conn);
            strSQL.Parameters.Add(":codigo", umLivro.getCodigo());
            strSQL.ExecuteNonQuery();
        }
    }
}
