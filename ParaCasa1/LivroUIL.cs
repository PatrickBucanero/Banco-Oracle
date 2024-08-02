using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParaCasa1
{
    public partial class LivroUIL : Form
    {
        Livro umLivro = new Livro();

        public LivroUIL()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            umLivro.setCodigo(textBox1.Text);
            umLivro.setTitulo(textBox2.Text);
            umLivro.setAutor(textBox3.Text);
            umLivro.setEditora(textBox4.Text);
            umLivro.setAno(textBox5.Text);

            LivroBLL.validaDados(umLivro);

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Dados inseridos com sucesso!");
        }

        private void CadLivrosUIL_Load(object sender, EventArgs e)
        {
            LivroBLL.conecta();
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            umLivro.setCodigo(textBox1.Text);
            LivroBLL.validaCodigo(umLivro);
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
            {
                textBox1.Text = umLivro.getCodigo();
                textBox2.Text = umLivro.getTitulo();
                textBox3.Text = umLivro.getAutor();
                textBox4.Text = umLivro.getEditora();
                textBox5.Text = umLivro.getAno();
            }
        }

        private void CadLivrosUIL_FormClosing(object sender, FormClosingEventArgs e)
        {
            LivroBLL.desconecta();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            umLivro.setCodigo(textBox1.Text);
            LivroBLL.excluiUmLivro(umLivro); // Corrigido para excluiumLivro
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Livro excluído com sucesso!");
        }


        private void button5_Click(object sender, EventArgs e)
        {
            umLivro.setCodigo(textBox1.Text);
            umLivro.setTitulo(textBox2.Text);
            umLivro.setAutor(textBox3.Text);
            umLivro.setEditora(textBox4.Text);
            umLivro.setAno(textBox5.Text);

            LivroBLL.alteraUmLivro(umLivro);

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Dados alterados com sucesso!");
        }


    }
    }

