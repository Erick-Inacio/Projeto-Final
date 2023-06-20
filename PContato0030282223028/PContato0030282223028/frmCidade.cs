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
    public partial class frmCidade : Form
    {
        private BindingSource bnCidade = new BindingSource();
        private bool bInclusao = false;
        private DataSet dsCidade = new DataSet();

        public frmCidade()
        {
            InitializeComponent();
        }

        private void frmCidade_Load(object sender, EventArgs e)
        {
            try
            {
                Cidade objCid = new Cidade();
                dsCidade.Tables.Add(objCid.Listar());
                bnCidade.DataSource = dsCidade.Tables["Cidade"];
                bnvCidade.BindingSource = bnCidade;
                dgvCidade.DataSource = bnCidade;
                txtIdCidade.DataBindings.Add("TEXT", bnCidade, "id_cidade");
                txtNomeCidade.DataBindings.Add("TEXT", bnCidade, "nome_cidade");
                cbxUf.DataBindings.Add("SelectedItem", bnCidade, "uf_cidade");
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar cidade!");
            }

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (tbCidade.SelectedIndex == 0)
            {
                tbCidade.SelectTab(1);
            }
            bnCidade.AddNew();
            txtNomeCidade.Enabled = true;
            cbxUf.Enabled = true;
            cbxUf.SelectedIndex = 0;
            txtNomeCidade.Focus();
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
            bInclusao = true; ;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (tbCidade.SelectedIndex == 0)
            {
                tbCidade.SelectTab(1);
            }
            if (MessageBox.Show("Confirma exclusão?", "Yes or No",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
           == DialogResult.Yes)
            {
                Cidade RegCid = new Cidade();
                RegCid.IdCidade = Convert.ToInt16(txtIdCidade.Text);
                RegCid.NomeCidade = txtNomeCidade.Text;
                RegCid.UfCidade = cbxUf.SelectedItem.ToString();
                if (RegCid.Excluir() > 0)
                {
                    MessageBox.Show("Cidade excluída com sucesso!");
                    Cidade R = new Cidade();
                    dsCidade.Tables.Clear();
                    dsCidade.Tables.Add(R.Listar());
                    bnCidade.DataSource = dsCidade.Tables["Cidade"];
                }
                else
                {
                    MessageBox.Show("Erro ao excluir cidade!");
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (tbCidade.SelectedIndex == 0)
            {
                tbCidade.SelectTab(1);
            }
            txtNomeCidade.Enabled = true;
            cbxUf.Enabled = true;
            txtNomeCidade.Focus();
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
            bInclusao = false;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // validar os dados
            if (txtNomeCidade.Text == "")
            {
                MessageBox.Show("Cidade inválida!");
            }
            else
            {
                Cidade RegCid = new Cidade();
                
                RegCid.NomeCidade = txtNomeCidade.Text;
                RegCid.UfCidade = cbxUf.SelectedItem.ToString();
                if (bInclusao)
                {
                    if (RegCid.Salvar() > 0)
                    {
                        MessageBox.Show("Cidade adicionada com sucesso!");
                        btnSalvar.Enabled = false;
                        txtIdCidade.Enabled = false;
                        txtNomeCidade.Enabled = false;
                        cbxUf.Enabled = false;
                        btnNovo.Enabled = true;
                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnAlterar.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;
                        bInclusao = false;
                        // recarrega o grid
                        dsCidade.Tables.Clear();
                        dsCidade.Tables.Add(RegCid.Listar());
                        bnCidade.DataSource = dsCidade.Tables["Cidade"];
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar cidade!");
                    }
                }
                else
                {
                    RegCid.IdCidade = Convert.ToInt16(txtIdCidade.Text);
                    if (RegCid.Alterar() > 0)
                    {
                        MessageBox.Show("Cidade alterada com sucesso!");
                        dsCidade.Tables.Clear();
                        dsCidade.Tables.Add(RegCid.Listar());
                        txtIdCidade.Enabled = false;
                        txtNomeCidade.Enabled = false;
                        cbxUf.Enabled = false;
                        btnNovo.Enabled = false;
                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;

                        dsCidade.Tables.Clear();
                        dsCidade.Tables.Add(RegCid.Listar());
                        bnCidade.DataSource = dsCidade.Tables["Cidade"];
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar cidade!");
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bnCidade.CancelEdit();
            btnSalvar.Enabled = false;
            txtNomeCidade.Enabled = false;
            cbxUf.Enabled = false;
            btnAlterar.Enabled = true;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dgvCidade_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}