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
        private DataSet dsCidade = new DataSet();
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
                txtEndereco.DataBindings.Add("TEXT", bnContato, "end_contato");
                txtCelular.DataBindings.Add("TEXT", bnContato, "cel_contato");
                txtEmail.DataBindings.Add("TEXT", bnContato, "email_contato");
                dtpData.DataBindings.Add("TEXT", bnContato, "dtcadastro_contato");
                btnCancelar.Enabled = false;
                btnSalvar.Enabled = false;

                Cidade Cid = new Cidade();
                dsCidade.Tables.Add(Cid.Listar());
                cbxCidade.Enabled = true;
                cbxCidade.DataSource = dsCidade.Tables["Cidade"];
                cbxCidade.DisplayMember = "nome_cidade";
                cbxCidade.ValueMember = "id_cidade";
                cbxCidade.DataBindings.Add("SelectedValue",
                    bnContato, "cidade_id_cidade");
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar Contato!");
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("contato inválida!");
            }
            else
            {
                Contato RegCont = new Contato();

                RegCont.NomeContato = txtNome.Text;
                RegCont.EndContato = txtEndereco.Text;
                //RegCont.ContatoIdContato=
                RegCont.CelContato = txtCelular.Text;
                RegCont.EmailContato = txtEmail.Text;
                // RegCont.DtCadastroContato=
                if (bInclusao)
                {
                    if (RegCont.Salvar() > 0)
                    {
                        MessageBox.Show("contato adicionada com sucesso!");
                        btnSalvar.Enabled = false;
                        txtId.Enabled = false;
                        txtNome.Enabled = false;
                        txtEndereco.Enabled = false;
                        txtCelular.Enabled = false;
                        txtEmail.Enabled = false;
                        dtpData.Enabled=false;
                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnAlterar.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;
                        bInclusao = false;
                        // recarrega o grid
                        dsContato.Tables.Clear();
                        dsContato.Tables.Add(RegCont.Listar());
                        bnContato.DataSource = dsContato.Tables["contato"];
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar contato!");
                    }
                }
                else
                {
                    RegCont.IdContato = Convert.ToInt16(txtId.Text);
                    if (RegCont.Alterar() > 0)
                    {
                        MessageBox.Show("contato alterada com sucesso!");
                        dsContato.Tables.Clear();
                        dsContato.Tables.Add(RegCont.Listar());
                        txtId.Enabled = false;
                        txtNome.Enabled = false;
                        txtEndereco.Enabled = false;
                        txtCelular.Enabled = false;
                        txtEmail.Enabled = false;
                        cbxCidade.Enabled = true;
                        dtpData.Enabled=false;
                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnAlterar.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;

                        dsContato.Tables.Clear();
                        dsContato.Tables.Add(RegCont.Listar());
                        bnContato.DataSource = dsContato.Tables["contato"];
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar contato!");
                    }
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (tbContato.SelectedIndex == 0)
            {
                tbContato.SelectTab(1);
            }
            bnContato.AddNew();
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            txtCelular.Enabled = true;
            txtEmail.Enabled=true;
            dtpData.Enabled=true;
            txtNome.Focus();
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnNovo.Enabled = true;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
            bInclusao = true; ;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (tbContato.SelectedIndex == 0)
            {
                tbContato.SelectTab(1);
            }
            txtNome.Enabled = true;
            txtEmail.Enabled= true;
            txtCelular.Enabled = true;
            txtEndereco.Enabled=true;
            dtpData.Enabled=true;   
            txtNome.Focus();
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
            bInclusao = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (tbContato.SelectedIndex == 0)
            {
                tbContato.SelectTab(1);
            }
            if (MessageBox.Show("Confirma exclusão?", "Yes or No",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
           == DialogResult.Yes)
            {
                Contato RegCont = new Contato();
                RegCont.IdContato = Convert.ToInt16(txtId.Text);
                RegCont.NomeContato = txtNome.Text;
                RegCont.EmailContato = txtEmail.Text;
                RegCont.EndContato=txtEndereco.Text;
                RegCont.CelContato= txtCelular.Text;
            
                if (RegCont.Excluir() > 0)
                {
                    MessageBox.Show("contato excluída com sucesso!");
                    Contato R = new Contato();
                    dsContato.Tables.Clear();
                    dsContato.Tables.Add(R.Listar());
                    bnContato.DataSource = dsContato.Tables["contato"];
                }
                else
                {
                    MessageBox.Show("Erro ao excluir contato!");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bnContato.CancelEdit();
            btnSalvar.Enabled = false;
            txtNome.Enabled = false;
            txtCelular.Enabled = false;
            txtEmail.Enabled = false;
            txtEndereco.Enabled = false;
            dtpData.Enabled = false;
            btnAlterar.Enabled = true;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {

        }
    }




}

