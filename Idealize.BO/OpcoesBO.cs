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
    /// Classe de Negocios da Tabela Opcoes
    /// </summary>
    public class OpcoesBO 
    {

        #region Variaveis Locais
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected OpcoesDAO OpcoesDAO;
        /// <summary>
        /// Objeto de segurança
        /// </summary>
        protected ObjectSecurity objectSecurity;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma instância da classe. Recebendo como parametro a conexao com banco de dados
        /// </summary>
        public OpcoesBO(System.Data.IDbConnection pIDbConnection, ObjectSecurity pObjectSecurity) : base()
        {
            OpcoesDAO = new OpcoesDAO(pIDbConnection, pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="OpcoesBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~OpcoesBO()
        {
            OpcoesDAO.Dispose();
        }

        #endregion

        #region WOLI - Métodos Básicos

        /// <summary>
        /// Realiza o insert do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser inserido</param>
        /// <returns>Objeto Inserido</returns>
        public Opcoes Insert(Opcoes pObject)
        {
            OpcoesDAO.BeginTransaction();
            try
            {
                Opcoes OpcoesAux = OpcoesDAO.InsertByStoredProcedure(pObject);
                pObject.idOpcao = OpcoesAux.idOpcao;

                OpcoesDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                OpcoesDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza o update do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atualizado</param>
        /// <returns>Objeto Atualizado</returns>
        public Opcoes Update(Opcoes pObject)
        {
            OpcoesDAO.BeginTransaction();
            try
            {
                OpcoesDAO.UpdateByStoredProcedure(pObject);

                OpcoesDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                OpcoesDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza a deleção do objeto por stored Procedure
        /// </summary>
        /// <param name="pidOpcao">PK da tabela</param>
        /// <returns>Quantidade de Registros deletados</returns>
        public int Delete(int pidOpcao)
        {
            int iRetorno = 0;
            OpcoesDAO.BeginTransaction();
            try
            {
                //iRetorno = OpcoesDAO.DeleteByStoredProcedure(pidOpcao, false, objectSecurity.UserSystem);
                OpcoesDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                OpcoesDAO.RollbackTransaction();
                throw ex;
            }
            return iRetorno;
        }

        /// <summary>
        /// Retorna registro pela PK
        /// </summary>
        /// <param name="pidOpcao">PK da tabela</param>
        /// <returns>Registro da PK</returns>
        public Opcoes SelectByPK(int pidOpcao)
        {
            return new Opcoes();
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
                OpcoesDAO = null;

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