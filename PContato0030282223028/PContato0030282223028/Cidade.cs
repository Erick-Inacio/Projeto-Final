using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PContato0030282223028
{
    class Cidade
    {
        //public int IdCidade { get; set; }
        //public int MyProperty { get; set; }
        private int _idCidade;
        private string _nomeCidade;
        private string _ufCidade;

        public int IdCidade { get => _idCidade; set => _idCidade = value; }
        public string NomeCidade { get => _nomeCidade; set => _nomeCidade = value; }
        public string UfCidade { get => _ufCidade; set => _ufCidade = value; }

        public DataTable Listar()
        {
            SqlDataAdapter daCidade;
            DataTable dtCidade = new DataTable();
            try
            {
                daCidade = new SqlDataAdapter("SELECT * FROM CIDADE",
                frmPrincipal.conexao);
                daCidade.Fill(dtCidade);
                daCidade.FillSchema(dtCidade, SchemaType.Source);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtCidade;
        }
        public int Salvar()
        {
            int retorno = 0;
            try
            {
                SqlCommand mycommand;
                mycommand = new SqlCommand("INSERT INTO CIDADE VALUES" +
                "(@nome_cidade, @uf_cidade)", frmPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@nome_cidade",
                SqlDbType.VarChar)); ;
                mycommand.Parameters.Add(new SqlParameter("@uf_cidade",
                SqlDbType.VarChar));
                mycommand.Parameters["@nome_cidade"].Value = NomeCidade;
                mycommand.Parameters["@uf_cidade"].Value = UfCidade;
                retorno = mycommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }
        public int Alterar()
        {
            int nReg = 0;

            try
            {
                SqlCommand mycommand;
                mycommand = new SqlCommand("UPDATE CIDADE SET nome_cidade = " +
                    "@nome_cidade, uf_cidade = @uf_cidade WHERE id_cidade = @id_cidade", frmPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@id_cidade",
                SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@nome_cidade",
                SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@uf_cidade",
                SqlDbType.Char));
                mycommand.Parameters["@id_cidade"].Value = IdCidade;
                mycommand.Parameters["@nome_cidade"].Value = NomeCidade;
                mycommand.Parameters["@uf_cidade"].Value = UfCidade;
                nReg = mycommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nReg;
        }
        public int Excluir()
        {
            int nReg = 0;
            try
            {
                SqlCommand mycommand;
                mycommand = new SqlCommand("DELETE FROM CIDADE WHERE id_cidade = @id_cidade",
                frmPrincipal.conexao);

                mycommand.Parameters.Add(new SqlParameter("@id_cidade",
                SqlDbType.Int));
                mycommand.Parameters["@id_cidade"].Value =
                Convert.ToInt16(IdCidade);
                nReg = mycommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nReg;
        }
    }
}

