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
    /// Classe de Negocios da Tabela Campanha
    /// </summary>
    public class CampanhaBO : IBaseBO<Campanha, int>
    {

        #region Variaveis Locais
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected CampanhaDAO CampanhaDAO;
        /// <summary>
        /// Objeto de segurança
        /// </summary>
        protected ObjectSecurity objectSecurity;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma instância da classe. Cria uma nova conexao com o banco de dados
        /// </summary>
        public CampanhaBO(ObjectSecurity pObjectSecurity) : base()
        {
            CampanhaDAO = new CampanhaDAO(ConnectionFactory.GetDbConnectionDefault(), pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Inicializa uma instância da classe. Recebendo como parametro a conexao com banco de dados
        /// </summary>
        public CampanhaBO(System.Data.IDbConnection pIDbConnection, ObjectSecurity pObjectSecurity) : base()
        {
            CampanhaDAO = new CampanhaDAO(pIDbConnection, pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="CampanhaBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~CampanhaBO()
        {
            CampanhaDAO.Dispose();
        }

        #endregion

        #region WOLI - Métodos Básicos

        /// <summary>
        /// Realiza o insert do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser inserido</param>
        /// <returns>Objeto Inserido</returns>
        public Campanha Insert(Campanha pObject)
        {
            CampanhaDAO.BeginTransaction();
            try
            {
                Campanha CampanhaAux = CampanhaDAO.InsertByStoredProcedure(pObject);
                pObject.idCampanha = CampanhaAux.idCampanha;

                CampanhaDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                CampanhaDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza o update do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atualizado</param>
        /// <returns>Objeto Atualizado</returns>
        public Campanha Update(Campanha pObject)
        {
            CampanhaDAO.BeginTransaction();
            try
            {
                CampanhaDAO.UpdateByStoredProcedure(pObject);

                CampanhaDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                CampanhaDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza a deleção do objeto por stored Procedure
        /// </summary>
        /// <param name="pidCampanha">PK da tabela</param>
        /// <returns>Quantidade de Registros deletados</returns>
        public int Delete(int pidCampanha)
        {
            int iRetorno = 0;
            CampanhaDAO.BeginTransaction();
            try
            {
                iRetorno = CampanhaDAO.DeleteByStoredProcedure(pidCampanha, false, objectSecurity.UserSystem);
                CampanhaDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                CampanhaDAO.RollbackTransaction();
                throw ex;
            }
            return iRetorno;
        }

        /// <summary>
        /// Retorna registro pela PK
        /// </summary>
        /// <param name="pidCampanha">PK da tabela</param>
        /// <returns>Registro da PK</returns>
        public Campanha SelectByPK(int pidCampanha)
        {
            return CampanhaDAO.SelectByPK(pidCampanha);
        }

        /// <summary>
        /// Realiza a busca Lookup
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atribuidos no filtro</param>
        /// <returns>Lista de Objetos que atendam ao filtro</returns>
        public IList<Campanha> ListForLookup(Campanha pObject)
        {
            return CampanhaDAO.ListForLookup(pObject);
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
        public IList<Campanha> ListForGrid(Campanha pObject, int pNumRegPag, int pNumPagina, string pDesOrdem, out int pNumTotReg)
        {
            return CampanhaDAO.ListForGrid(pObject, pNumRegPag, pNumPagina, pDesOrdem, out pNumTotReg);
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
                CampanhaDAO = null;

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
