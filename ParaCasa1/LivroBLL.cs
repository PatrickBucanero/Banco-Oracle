using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Todos os campos são de preenchimento obrigatorio
 * Ano de edição deverá ser numérico e positivo
*/

namespace ParaCasa1
{
    class LivroBLL
    {
        public static void conecta()
        {
            LivroDAL.Conecta();
        }

        public static void desconecta()
        {
            LivroDAL.Desconecta();
        }

        public static void validaCodigo(Livro umLivro)
        {
            Erro.setErro(false);
            if (umLivro.getCodigo().Equals(""))
            {
                Erro.setMsg("O código é de preenchimento obrigatório!");
                return;
            }
            LivroDAL.ConsultarUmLivro(umLivro);
        }

        public static void validaDados(Livro umLivro)
        {
            Erro.setErro(false);
            if (umLivro.getCodigo().Equals(""))
            {
                Erro.setMsg("O código é de preenchimento obrigatório!");
                return;
            }
            if (umLivro.getTitulo().Equals(""))
            {
                Erro.setMsg("O titulo é de preenchimento obrigatório!");
                return;
            }
            if (umLivro.getAutor().Equals(""))
            {
                Erro.setMsg("A autor é de preenchimento obrigatório!");
                return;
            }
            if (umLivro.getEditora().Equals(""))
            {
                Erro.setMsg("A editora é de preenchimento obrigatório!");
                return;
            }
            if (umLivro.getAno().Equals(""))
            {
                Erro.setMsg("O ano é de preenchimento obrigatório!");
                return;
            }

            LivroDAL.InserirUmLivro(umLivro);

        }

        public static void excluiUmLivro(Livro umLivro)
        {
            Erro.setErro(false);

           
            if (umLivro.getCodigo().Equals(""))
            {
                Erro.setMsg("O código é de preenchimento obrigatório!");
                return;
            }

            
            if (!LivroDAL.ExisteLivro(umLivro.getCodigo()))
            {
                Erro.setMsg("Não foi possível encontrar um livro com o código especificado.");
                return;
            }

            LivroDAL.ExcluirUmLivro(umLivro);
        }
        public static void alteraUmLivro(Livro umLivro)
        {
            Erro.setErro(false);

            
            if (umLivro.getCodigo().Equals(""))
            {
                Erro.setMsg("O código é de preenchimento obrigatório!");
                return;
            }

            
            if (!LivroDAL.ExisteLivro(umLivro.getCodigo()))
            {
                Erro.setMsg("Não foi possível encontrar um livro com o código especificado.");
                return;
            }

            
            if (umLivro.getTitulo().Equals(""))
            {
                Erro.setMsg("O titulo é de preenchimento obrigatório!");
                return;
            }
            if (umLivro.getAutor().Equals(""))
            {
                Erro.setMsg("O autor é de preenchimento obrigatório!");
                return;
            }
            if (umLivro.getEditora().Equals(""))
            {
                Erro.setMsg("A editora é de preenchimento obrigatório!");
                return;
            }
            if (umLivro.getAno().Equals(""))
            {
                Erro.setMsg("O ano é de preenchimento obrigatório!");
                return;
            }
            
            LivroDAL.AlterarUmLivro(umLivro);
        }


    }
}


