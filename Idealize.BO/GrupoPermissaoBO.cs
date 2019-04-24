using System;
using System.Collections.Generic;
using Sistema.Arquitetura.Library.Core;
using Sistema.Arquitetura.Library.Core.Interface;
using Sistema.Arquitetura.Library.Core.Util.Security;
using Idealize.VO;
using Idealize.DAO;

namespace Idealize.BO
{

    /// <summary>
    /// Classe de Negocios da Tabela GrupoPermissao
    /// </summary>
    public class GrupoPermissaoBO 
    {

        #region Variaveis Locais
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected GrupoPermissaoDAO GrupoPermissaoDAO;
        /// <summary>
        /// Objeto de segurança
        /// </summary>
        protected ObjectSecurity objectSecurity;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma instância da classe. Recebendo como parametro a conexao com banco de dados
        /// </summary>
        public GrupoPermissaoBO(System.Data.IDbConnection pIDbConnection, ObjectSecurity pObjectSecurity) : base()
        {
            GrupoPermissaoDAO = new GrupoPermissaoDAO(pIDbConnection, pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="GrupoPermissaoBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~GrupoPermissaoBO()
        {
            GrupoPermissaoDAO.Dispose();
        }

        #endregion

        #region WOLI - Métodos Básicos

        /// <summary>
        /// Realiza o insert do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser inserido</param>
        /// <returns>Objeto Inserido</returns>
        public GrupoPermissao Insert(GrupoPermissao pObject)
        {
            GrupoPermissaoDAO.BeginTransaction();
            try
            {
                GrupoPermissao GrupoPermissaoAux = GrupoPermissaoDAO.InsertByStoredProcedure(pObject);
                pObject.idGrupo = GrupoPermissaoAux.idGrupo;

                GrupoPermissaoDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                GrupoPermissaoDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza o update do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atualizado</param>
        /// <returns>Objeto Atualizado</returns>
        public GrupoPermissao Update(GrupoPermissao pObject)
        {
            GrupoPermissaoDAO.BeginTransaction();
            try
            {
                GrupoPermissaoDAO.UpdateByStoredProcedure(pObject);

                GrupoPermissaoDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                GrupoPermissaoDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza a deleção do objeto por stored Procedure
        /// </summary>
        /// <param name="pidGrupo">PK da tabela</param>
        /// <returns>Quantidade de Registros deletados</returns>
        public int Delete(int pidGrupo)
        {
            int iRetorno = 0;
            GrupoPermissaoDAO.BeginTransaction();
            try
            {
                //iRetorno = GrupoPermissaoDAO.DeleteByStoredProcedure(pidGrupo, false, objectSecurity.UserSystem);
                GrupoPermissaoDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                GrupoPermissaoDAO.RollbackTransaction();
                throw ex;
            }
            return iRetorno;
        }

        /// <summary>
        /// Retorna registro pela PK
        /// </summary>
        /// <param name="pidGrupo">PK da tabela</param>
        /// <returns>Registro da PK</returns>
        public GrupoPermissao SelectByPK(int pidGrupo)
        {
            return new GrupoPermissao();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {

            if (!disposedValue)
            {

                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                objectSecurity = null;
                GrupoPermissaoDAO = null;

                disposedValue = true;
            }
        }

        /// <summary>
        /// This code added to correctly implement the disposable pattern.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion

        #endregion

        #region Metodos Personalizados

        #endregion
    }
}
