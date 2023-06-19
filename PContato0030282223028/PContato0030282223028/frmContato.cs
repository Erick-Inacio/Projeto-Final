using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PContato0030282223028
{
    public partial class frmContato : Form
    {
        private BindingSource bnContato = new BindingSource();
        private bool bInclusao = false;
        private DataSet dsContato = new DataSet();
        public frmContato()
        {
            InitializeComponent();
        }
        private void frmContato_Load(object sender, EventArgs e)
        {
            try
            {
                Contato objCon = new Contato();
                dsContato.Tables.Add(objCon.Listar());
                bnContato.DataSource = dsContato.Tables["Contato"];
                bnvContato.BindingSource = bnContato;
                dgvContato.DataSource = bnContato;
                txtId.DataBindings.Add("TEXT", bnContato, "id_contato");
                txtNome.DataBindings.Add("TEXT", bnContato, "nome_contato");
                txtEndereco.DataBindings.Add("SelectedItem", bnContato, "end_contato");
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar Contato!");
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tr(object sender, EventArgs e)
        {

        }

      
    }
}
