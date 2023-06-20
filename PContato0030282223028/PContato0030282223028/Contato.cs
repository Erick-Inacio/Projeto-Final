using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PContato0030282223028
{
    internal class Contato
    {
        public int IdContato { get; set; }
        public string NomeContato { get; set; }
        public string EndContato { get; set; }
        public int CidadeIdCidade { get; set; }
        public string CelContato { get; set; }
        public string EmailContato { get; set; }
        public DateTime DtCadastroContato { get; set; }

        public DataTable Listar()
        {
            SqlDataAdapter daContato;
            DataTable dtContato = new DataTable();
            try
            {
                daContato = new SqlDataAdapter("SELECT * FROM CONTATO",
                frmPrincipal.conexao);
                daContato.Fill(dtContato);
                daContato.FillSchema(dtContato, SchemaType.Source);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContato;
        }
            public int Salvar()
            {
                int retorno = 0;
                try
                {
                    SqlCommand mycommand;
                    mycommand = new SqlCommand("INSERT INTO CONTATO VALUES" +
                    "(@NomeContato, @EndContato, @CidadeIdCidade, @CelContato," +
                    "@EmailContato, @DtCadastroContato)", frmPrincipal.conexao);

                    mycommand.Parameters.Add(new SqlParameter("@NomeContato",
                    SqlDbType.VarChar));
                    mycommand.Parameters.Add(new SqlParameter("@EndContato",
                    SqlDbType.VarChar));
                    mycommand.Parameters.Add(new SqlParameter("@CidadeIdCidade",
                    SqlDbType.Int));
                    mycommand.Parameters.Add(new SqlParameter("@CelContato",
                    SqlDbType.VarChar));
                    mycommand.Parameters.Add(new SqlParameter("@EmailContato",
                    SqlDbType.VarChar));
                    mycommand.Parameters.Add(new SqlParameter("@DtCadastroContato",
                    SqlDbType.Date));

                    mycommand.Parameters["@NomeContato"].Value = NomeContato;
                    mycommand.Parameters["@EndContato"].Value = EndContato;
                    mycommand.Parameters["@CidadeIdCidade"].Value = CidadeIdCidade;
                    mycommand.Parameters["@CelContato"].Value = CelContato;
                    mycommand.Parameters["@EmailContato"].Value = EmailContato;
                    mycommand.Parameters["@DtCadastroContato"].Value = DtCadastroContato;

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
                    mycommand = new SqlCommand("UPDATE CONTATO SET nome_contato = " +
                        "@NomeContato, end_contato = @EndContato, cidade_id = @CidadeIdCidade," +
                        "cel_contato = @CelContato, email_contato = @EmailContato, " +
                        "dtcadastro_contato = @DtCadastroContato WHERE id_contato = @id_contato", frmPrincipal.conexao);

                    mycommand.Parameters.Add(new SqlParameter("@IdContato",
                    SqlDbType.Int));
                    mycommand.Parameters.Add(new SqlParameter("@NomeContato",
                    SqlDbType.VarChar));
                    mycommand.Parameters.Add(new SqlParameter("@EndContato",
                    SqlDbType.VarChar));
                    mycommand.Parameters.Add(new SqlParameter("@CidadeIdCidade",
                    SqlDbType.Int));
                    mycommand.Parameters.Add(new SqlParameter("@CelContato",
                    SqlDbType.VarChar));
                    mycommand.Parameters.Add(new SqlParameter("@EmailContato",
                    SqlDbType.VarChar));
                    mycommand.Parameters.Add(new SqlParameter("@DtCadastroContato",
                    SqlDbType.Date));

                    mycommand.Parameters["@NomeContato"].Value = NomeContato;
                    mycommand.Parameters["@EndContato"].Value = EndContato;
                    mycommand.Parameters["@CidadeIdCidade"].Value = CidadeIdCidade;
                    mycommand.Parameters["@CelContato"].Value = CelContato;
                    mycommand.Parameters["@EmailContato"].Value = EmailContato;
                    mycommand.Parameters["@IdContato"].Value = IdContato;
                    mycommand.Parameters["@DtCadastroContato"].Value = DtCadastroContato;
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
                    mycommand = new SqlCommand("DELETE FROM TBCONTATO WHERE id_contato = @IdContato",
                    frmPrincipal.conexao);

                    mycommand.Parameters.Add(new SqlParameter("@IdContato",
                    SqlDbType.Int));
                    mycommand.Parameters["@IdContato"].Value = IdContato;
                    Convert.ToInt16(IdContato);
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
