using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace PContato0030282223028
{
    public partial class frmPrincipal : Form
    {
        public static SqlConnection conexao;
        public frmPrincipal()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection("Data Source=erick\\sqlexpress;Initial Catalog=erick\\lp2;Integrated Security=True;Pooling=False");
                conexao.Open();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Erro de banco de dados =/" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Outros Erros=/" + ex.Message);
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmCidade>("frmCidade");
        }

        private void contatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmContato>("frmContato");
        }

        private void AbrirFormulario<T>(string formularioName) where T : Form, new()
        {
            var formulario = Application.OpenForms.OfType<T>().FirstOrDefault();
            if (formulario != null)
            {
                formulario.BringToFront();
            }
            else
            {
                formulario = new T();
                formulario.MdiParent = this;
                formulario.WindowState = FormWindowState.Maximized;
                formulario.Show();
            }
        }
    }
}
