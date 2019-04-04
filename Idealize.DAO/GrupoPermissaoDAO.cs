using Sistema.Arquitetura.Library.Core;
using Sistema.Arquitetura.Library.Core.Interface;
using Sistema.Arquitetura.Library.Core.Util.Security;
using Idealize.VO;

namespace Idealize.DAO

{
    /// <summary>
    /// Classe de Acesso a Dados da Tabela aluno
    /// </summary>
    public class GrupoPermissaoDAO : NativeDAO<GrupoPermissao>, IBaseDAO<GrupoPermissao, int>
    {

        /// <summary>
        /// Inicializa uma instância da classe
        /// </summary>
        /// <param name="connection">Recebendo como parametro a conexao com banco de dados</param>
        /// <param name="objectSecurity">Objeto de segurança</param>
        /// <returns>Objeto inserido</returns>
        public GrupoPermissaoDAO(System.Data.IDbConnection connection, ObjectSecurity objectSecurity) : base(connection, objectSecurity)
        {
        }

        #region Métodos de Persistência Básicos

        /// <summary>
        /// Realiza o insert do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser inserido</param>
        /// <returns>Objeto Inserido</returns>
        public GrupoPermissao InsertByStoredProcedure(GrupoPermissao pObject)
        {
            string sql = "dbo.I_sp_GrupoPermissao";
            StatementDAO statement = new StatementDAO(sql);
            statement.AddParameter("descricao", pObject.descricao);
            return this.ExecuteReturnT(statement);
        }

        /// <summary>
        /// Realiza o update do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atualizado</param>
        /// <returns>Objeto Atualizado</returns>
        public GrupoPermissao UpdateByStoredProcedure(GrupoPermissao pObject)
        {
            string sql = "dbo.U_sp_GrupoPermissao";
            StatementDAO statement = new StatementDAO(sql);
            statement.AddParameter("idGrupo", pObject.idGrupo);
            statement.AddParameter("Descricao", pObject.descricao);

            return this.ExecuteReturnT(statement);
        }

        /// <summary>
        /// Realiza a deleção do objeto por stored Procedure
        /// </summary>
        /// <param name="idObject">PK da tabela</param>
        /// <returns>Quantidade de Registros deletados</returns>
        public int DeleteByStoredProcedure(GrupoPermissao pObject, bool flExclusaoLogica, int userSystem)
        {
            string sql = "dbo.D_sp_GrupoPermissao";
            StatementDAO statement = new StatementDAO(sql);
            statement.AddParameter("idGrupo", pObject.idGrupo);
            return this.ExecuteNonQuery(statement);
        }

        /// <summary>
        /// Retorna registro pela PK
        /// </summary>
        /// <param name="idObject">PK da tabela</param>
        /// <returns>Registro da PK</returns>
        public GrupoPermissao SelectByPK(GrupoPermissao pObject)
        {
            string sql = "dbo.S_sp_GrupoPermissao";
            StatementDAO statement = new StatementDAO(sql);
            statement.AddParameter("idGrupo", pObject.idGrupo);
            return this.ExecuteReturnT(statement);
        }
        #endregion

        #region Métodos Personalizados

        #endregion
    }
}
