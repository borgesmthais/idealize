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
    /// Classe de Negocios da Tabela Resposta
    /// </summary>
    public class RespostaBO 
    {

        #region Variaveis Locais
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected RespostaDAO RespostaDAO;
        /// <summary>
        /// Objeto de segurança
        /// </summary>
        protected ObjectSecurity objectSecurity;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma instância da classe. Recebendo como parametro a conexao com banco de dados
        /// </summary>
        public RespostaBO(System.Data.IDbConnection pIDbConnection, ObjectSecurity pObjectSecurity) : base()
        {
            RespostaDAO = new RespostaDAO(pIDbConnection, pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="RespostaBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~RespostaBO()
        {
            RespostaDAO.Dispose();
        }

        #endregion

        #region WOLI - Métodos Básicos

        /// <summary>
        /// Realiza o insert do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser inserido</param>
        /// <returns>Objeto Inserido</returns>
        public Resposta Insert(Resposta pObject)
        {
            RespostaDAO.BeginTransaction();
            try
            {
                Resposta RespostaAux = RespostaDAO.InsertByStoredProcedure(pObject);
                pObject.idResposta = RespostaAux.idResposta;

                RespostaDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                RespostaDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza o update do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atualizado</param>
        /// <returns>Objeto Atualizado</returns>
        public Resposta Update(Resposta pObject)
        {
            RespostaDAO.BeginTransaction();
            try
            {
                RespostaDAO.UpdateByStoredProcedure(pObject);

                RespostaDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                RespostaDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza a deleção do objeto por stored Procedure
        /// </summary>
        /// <param name="pidResposta">PK da tabela</param>
        /// <returns>Quantidade de Registros deletados</returns>
        public int Delete(int pidResposta)
        {
            int iRetorno = 0;
            RespostaDAO.BeginTransaction();
            try
            {
               // iRetorno = RespostaDAO.DeleteByStoredProcedure(pidResposta, false, objectSecurity.UserSystem);
                RespostaDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                RespostaDAO.RollbackTransaction();
                throw ex;
            }
            return iRetorno;
        }

        /// <summary>
        /// Retorna registro pela PK
        /// </summary>
        /// <param name="pidResposta">PK da tabela</param>
        /// <returns>Registro da PK</returns>
        public Resposta SelectByPK(int pidResposta)
        {
            return new Resposta();
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
                RespostaDAO = null;

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

