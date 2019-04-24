using System;
using Sistema.Arquitetura.Library.Core.Util.Security;
using Idealize.VO;
using Idealize.DAO;

namespace Idealize.BO
{

    /// <summary>
    /// Classe de Negocios da Tabela TemplateQuestoes
    /// </summary>
    public class TemplateQuestoesBO 
    {

        #region Variaveis Locais
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected TemplateQuestoesDAO TemplateQuestoesDAO;
        /// <summary>
        /// Objeto de segurança
        /// </summary>
        protected ObjectSecurity objectSecurity;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma instância da classe. Recebendo como parametro a conexao com banco de dados
        /// </summary>
        public TemplateQuestoesBO(System.Data.IDbConnection pIDbConnection, ObjectSecurity pObjectSecurity) : base()
        {
            TemplateQuestoesDAO = new TemplateQuestoesDAO(pIDbConnection, pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="TemplateQuestoesBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~TemplateQuestoesBO()
        {
            TemplateQuestoesDAO.Dispose();
        }

        #endregion

        #region WOLI - Métodos Básicos

        /// <summary>
        /// Realiza o insert do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser inserido</param>
        /// <returns>Objeto Inserido</returns>
        public TemplateQuestoes Insert(TemplateQuestoes pObject)
        {
            TemplateQuestoesDAO.BeginTransaction();
            try
            {
                TemplateQuestoes TemplateQuestoesAux = TemplateQuestoesDAO.InsertByStoredProcedure(pObject);
                pObject.idTemplateQuestao = TemplateQuestoesAux.idTemplateQuestao;

                TemplateQuestoesDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                TemplateQuestoesDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza o update do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atualizado</param>
        /// <returns>Objeto Atualizado</returns>
        public TemplateQuestoes Update(TemplateQuestoes pObject)
        {
            TemplateQuestoesDAO.BeginTransaction();
            try
            {
                TemplateQuestoesDAO.UpdateByStoredProcedure(pObject);

                TemplateQuestoesDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                TemplateQuestoesDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza a deleção do objeto por stored Procedure
        /// </summary>
        /// <param name="pidTemplateQuestao">PK da tabela</param>
        /// <returns>Quantidade de Registros deletados</returns>
        public int Delete(int pidTemplateQuestao)
        {
            int iRetorno = 0;
            TemplateQuestoesDAO.BeginTransaction();
            try
            {
                //iRetorno = TemplateQuestoesDAO.DeleteByStoredProcedure(pidTemplateQuestao, false, objectSecurity.UserSystem);
                TemplateQuestoesDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                TemplateQuestoesDAO.RollbackTransaction();
                throw ex;
            }
            return iRetorno;
        }

        /// <summary>
        /// Retorna registro pela PK
        /// </summary>
        /// <param name="pidTemplateQuestao">PK da tabela</param>
        /// <returns>Registro da PK</returns>
        public TemplateQuestoes SelectByPK(int pidTemplateQuestao)
        {
            return new TemplateQuestoes();
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
                TemplateQuestoesDAO = null;

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