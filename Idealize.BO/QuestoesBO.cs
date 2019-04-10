using System;
using System.Collections.Generic;
using System.Text;

namespace Idealize.BO
{

    /// <summary>
    /// Classe de Negocios da Tabela Questoes
    /// </summary>
    public class QuestoesBO : IBaseBO<Questoes, int>
    {

        #region Variaveis Locais
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected QuestoesDAO QuestoesDAO;
        /// <summary>
        /// Objeto de segurança
        /// </summary>
        protected ObjectSecurity objectSecurity;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma instância da classe. Cria uma nova conexao com o banco de dados
        /// </summary>
        public QuestoesBO(ObjectSecurity pObjectSecurity) : base()
        {
            QuestoesDAO = new QuestoesDAO(ConnectionFactory.GetDbConnectionDefault(), pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Inicializa uma instância da classe. Recebendo como parametro a conexao com banco de dados
        /// </summary>
        public QuestoesBO(System.Data.IDbConnection pIDbConnection, ObjectSecurity pObjectSecurity) : base()
        {
            QuestoesDAO = new QuestoesDAO(pIDbConnection, pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="QuestoesBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~QuestoesBO()
        {
            QuestoesDAO.Dispose();
        }

        #endregion

        #region WOLI - Métodos Básicos

        /// <summary>
        /// Realiza o insert do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser inserido</param>
        /// <returns>Objeto Inserido</returns>
        public Questoes Insert(Questoes pObject)
        {
            QuestoesDAO.BeginTransaction();
            try
            {
                Questoes QuestoesAux = QuestoesDAO.InsertByStoredProcedure(pObject);
                pObject.idQuestao = QuestoesAux.idQuestao;

                QuestoesDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                QuestoesDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza o update do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atualizado</param>
        /// <returns>Objeto Atualizado</returns>
        public Questoes Update(Questoes pObject)
        {
            QuestoesDAO.BeginTransaction();
            try
            {
                QuestoesDAO.UpdateByStoredProcedure(pObject);

                QuestoesDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                QuestoesDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza a deleção do objeto por stored Procedure
        /// </summary>
        /// <param name="pidQuestao">PK da tabela</param>
        /// <returns>Quantidade de Registros deletados</returns>
        public int Delete(int pidQuestao)
        {
            int iRetorno = 0;
            QuestoesDAO.BeginTransaction();
            try
            {
                iRetorno = QuestoesDAO.DeleteByStoredProcedure(pidQuestao, false, objectSecurity.UserSystem);
                QuestoesDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                QuestoesDAO.RollbackTransaction();
                throw ex;
            }
            return iRetorno;
        }

        /// <summary>
        /// Retorna registro pela PK
        /// </summary>
        /// <param name="pidQuestao">PK da tabela</param>
        /// <returns>Registro da PK</returns>
        public Questoes SelectByPK(int pidQuestao)
        {
            return QuestoesDAO.SelectByPK(pidQuestao);
        }

        /// <summary>
        /// Realiza a busca Lookup
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atribuidos no filtro</param>
        /// <returns>Lista de Objetos que atendam ao filtro</returns>
        public IList<Questoes> ListForLookup(Questoes pObject)
        {
            return QuestoesDAO.ListForLookup(pObject);
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
        public IList<Questoes> ListForGrid(Questoes pObject, int pNumRegPag, int pNumPagina, string pDesOrdem, out int pNumTotReg)
        {
            return QuestoesDAO.ListForGrid(pObject, pNumRegPag, pNumPagina, pDesOrdem, out pNumTotReg);
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
                QuestoesDAO = null;

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