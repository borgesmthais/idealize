﻿using System;
using System.Collections.Generic;
using Idealize.BO.Factory;
using Sistema.Arquitetura.Library.Core;
using Sistema.Arquitetura.Library.Core.Interface;
using Sistema.Arquitetura.Library.Core.Util.Security;
using Idealize.VO;
using Idealize.DAO;

namespace Idealize.BO
{

    /// <summary>
    /// Classe de Negocios da Tabela TipoQuestao
    /// </summary>
    public class TipoQuestaoBO : IBaseBO<TipoQuestao, int>
    {

        #region Variaveis Locais
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected TipoQuestaoDAO TipoQuestaoDAO;
        /// <summary>
        /// Objeto de segurança
        /// </summary>
        protected ObjectSecurity objectSecurity;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma instância da classe. Cria uma nova conexao com o banco de dados
        /// </summary>
        public TipoQuestaoBO(ObjectSecurity pObjectSecurity) : base()
        {
            TipoQuestaoDAO = new TipoQuestaoDAO(ConnectionFactory.GetDbConnectionDefault(), pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Inicializa uma instância da classe. Recebendo como parametro a conexao com banco de dados
        /// </summary>
        public TipoQuestaoBO(System.Data.IDbConnection pIDbConnection, ObjectSecurity pObjectSecurity) : base()
        {
            TipoQuestaoDAO = new TipoQuestaoDAO(pIDbConnection, pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="TipoQuestaoBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~TipoQuestaoBO()
        {
            TipoQuestaoDAO.Dispose();
        }

        #endregion

        #region WOLI - Métodos Básicos

        /// <summary>
        /// Realiza o insert do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser inserido</param>
        /// <returns>Objeto Inserido</returns>
        public TipoQuestao Insert(TipoQuestao pObject)
        {
            TipoQuestaoDAO.BeginTransaction();
            try
            {
                TipoQuestao TipoQuestaoAux = TipoQuestaoDAO.InsertByStoredProcedure(pObject);
                pObject.idTipoQuestao = TipoQuestaoAux.idTipoQuestao;

                TipoQuestaoDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                TipoQuestaoDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza o update do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atualizado</param>
        /// <returns>Objeto Atualizado</returns>
        public TipoQuestao Update(TipoQuestao pObject)
        {
            TipoQuestaoDAO.BeginTransaction();
            try
            {
                TipoQuestaoDAO.UpdateByStoredProcedure(pObject);

                TipoQuestaoDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                TipoQuestaoDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza a deleção do objeto por stored Procedure
        /// </summary>
        /// <param name="pidTipoQuestao">PK da tabela</param>
        /// <returns>Quantidade de Registros deletados</returns>
        public int Delete(int pidTipoQuestao)
        {
            int iRetorno = 0;
            TipoQuestaoDAO.BeginTransaction();
            try
            {
                iRetorno = TipoQuestaoDAO.DeleteByStoredProcedure(pidTipoQuestao, false, objectSecurity.UserSystem);
                TipoQuestaoDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                TipoQuestaoDAO.RollbackTransaction();
                throw ex;
            }
            return iRetorno;
        }

        /// <summary>
        /// Retorna registro pela PK
        /// </summary>
        /// <param name="pidTipoQuestao">PK da tabela</param>
        /// <returns>Registro da PK</returns>
        public TipoQuestao SelectByPK(int pidTipoQuestao)
        {
            return TipoQuestaoDAO.SelectByPK(pidTipoQuestao);
        }

        /// <summary>
        /// Realiza a busca Lookup
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atribuidos no filtro</param>
        /// <returns>Lista de Objetos que atendam ao filtro</returns>
        public IList<TipoQuestao> ListForLookup(TipoQuestao pObject)
        {
            return TipoQuestaoDAO.ListForLookup(pObject);
        }

        /// <summary>
        /// Realiza a busca pelos parametros informados no objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atribuidos no filtro</param>
        /// <param name="pNumRegPag">Número de registros por página</param>
        /// <param name="pNumPagina">Página corrente</param>
        /// <param name="pDesOrdem">Critério de ordenação</param>
        /// <param name="pNumTotReg">Quantidade de registros que a consulta retorna</param>
        /// <returns>Lista de Objetos que atendam ao filtro</returns>
        public IList<TipoQuestao> ListForGrid(TipoQuestao pObject, int pNumRegPag, int pNumPagina, string pDesOrdem, out int pNumTotReg)
        {
            return TipoQuestaoDAO.ListForGrid(pObject, pNumRegPag, pNumPagina, pDesOrdem, out pNumTotReg);
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
                TipoQuestaoDAO = null;

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

