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
                conexao = new SqlConnection("Data Source=Erick\\SQLExpress;Initial Catalog=LP2;Integrated Security=True");
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
            frmCidade objCidade = new frmCidade();
            objCidade.MdiParent = this;
            objCidade.WindowState = FormWindowState.Maximized;
            objCidade.Show();
        }

        private void contatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContato objContato = new frmContato();
            objContato.MdiParent = this;
            objContato.WindowState = FormWindowState.Maximized;
            objContato.Show();
        }
    }
}
