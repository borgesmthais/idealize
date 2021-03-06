﻿using Sistema.Arquitetura.Library.Core;
using Sistema.Arquitetura.Library.Core.Util.Security;
using Idealize.VO;
using System.Data;
using System.Data.SqlClient;

namespace Idealize.DAO

{
    /// <summary>
    /// Classe de Acesso a Dados da Tabela aluno
    /// </summary>
    public class FuncionarioDAO : NativeDAO<Funcionario>
    {
        private SqlConnection conn = new SqlConnection();
        /// <summary>
        /// Inicializa uma instância da classe
        /// </summary>
        /// <param name="connection">Recebendo como parametro a conexao com banco de dados</param>
        /// <param name="objectSecurity">Objeto de segurança</param>
        /// <returns>Objeto inserido</returns>
        public FuncionarioDAO(System.Data.IDbConnection connection, ObjectSecurity objectSecurity) : base(connection, objectSecurity)
        {
            string aux = connection.ConnectionString;
            conn.ConnectionString = aux;
        }

        #region Métodos de Persistência Básicos

        /// <summary>
        /// Realiza o insert do objeto por stored Procedure
        /// 
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser inserido</param>
        /// <returns>Objeto Inserido</returns>
        public Funcionario InsertByStoredProcedure(Funcionario pObject)
        {
            string sql = "dbo.pr_ins_Funcionario";
            StatementDAO statement = new StatementDAO(sql);
            statement.AddParameter("Login", pObject.login);
            statement.AddParameter("Nome", pObject.nome);
            statement.AddParameter("CPF", pObject.cpf);
            statement.AddParameter("Senha", pObject.senha);
            statement.AddParameter("LoginSemSucesso", pObject.loginSemSucesso);
            statement.AddParameter("idGrupo", pObject.idGrupo);
            return this.ExecuteReturnT(statement);
        }

        /// <summary>
        /// Realiza o update do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atualizado</param>
        /// <returns>Objeto Atualizado</returns>
        public Funcionario UpdateByStoredProcedure(Funcionario pObject)
        {
            string sql = "dbo.U_sp_Funcionario";
            StatementDAO statement = new StatementDAO(sql);
            statement.AddParameter("idFuncionario", pObject.idFuncionario);
            statement.AddParameter("Login", pObject.login);
            statement.AddParameter("Nome", pObject.nome);
            statement.AddParameter("CPF", pObject.cpf);
            statement.AddParameter("Senha", pObject.senha);
            statement.AddParameter("LoginSemSucesso", pObject.loginSemSucesso);
            statement.AddParameter("idGrupo", pObject.idGrupo);

            return this.ExecuteReturnT(statement);
        }

        /// <summary>
        /// Realiza a deleção do objeto por stored Procedure
        /// </summary>
        /// <param name="idObject">PK da tabela</param>
        /// <returns>Quantidade de Registros deletados</returns>
        public int DeleteByStoredProcedure(int idFuncionario, bool flExclusaoLogica, int userSystem)
        {
            string sql = "dbo.D_sp_Funcionario";
            StatementDAO statement = new StatementDAO(sql);
            statement.AddParameter("idFuncionario", idFuncionario);
            return this.ExecuteNonQuery(statement);
        }

        /// <summary>
        /// Retorna registro pela PK
        /// </summary>
        /// <param name="idObject">PK da tabela</param>
        /// <returns>Registro da PK</returns>
        public Funcionario SelectByPK(int idFuncionario)
        {
            string sql = "dbo.S_sp_Funcionario";
            StatementDAO statement = new StatementDAO(sql);
            statement.AddParameter("idFuncionario", idFuncionario);
            return this.ExecuteReturnT(statement);
        }

        /// <summary>
        /// Retorna registro pela PK
        /// </summary>
        /// <param name="idObject">PK da tabela</param>
        /// <returns>Registro da PK</returns>
        public Funcionario AutenticaLogin(Funcionario pObject)
        {
            string sql = "dbo.S_sp_LoginFuncionario";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@login", pObject.login);
            cmd.Parameters.AddWithValue("@senha", pObject.senha);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            conn.Open();

            var rdr = cmd.ExecuteReader();

            Funcionario funcionario = null;

            while (rdr.Read())
            {
                funcionario = new Funcionario();
                funcionario.idFuncionario = (int)rdr["idFuncionario"];
                funcionario.idGrupo = (int)rdr["idGrupo"];
            }

            return funcionario;
        }
        #endregion

        #region Métodos Personalizados

        #endregion
    }
}
