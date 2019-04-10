using System;
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
    /// Classe de Negocios da Tabela Questionario
    /// </summary>
    public class QuestionarioBO : IBaseBO<Questionario, int>
    {

        #region Variaveis Locais
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected QuestionarioDAO QuestionarioDAO;
        /// <summary>
        /// Objeto de segurança
        /// </summary>
        protected ObjectSecurity objectSecurity;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma instância da classe. Cria uma nova conexao com o banco de dados
        /// </summary>
        public QuestionarioBO(ObjectSecurity pObjectSecurity) : base()
        {
            QuestionarioDAO = new QuestionarioDAO(ConnectionFactory.GetDbConnectionDefault(), pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Inicializa uma instância da classe. Recebendo como parametro a conexao com banco de dados
        /// </summary>
        public QuestionarioBO(System.Data.IDbConnection pIDbConnection, ObjectSecurity pObjectSecurity) : base()
        {
            QuestionarioDAO = new QuestionarioDAO(pIDbConnection, pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="QuestionarioBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~QuestionarioBO()
        {
            QuestionarioDAO.Dispose();
        }

        #endregion

        #region WOLI - Métodos Básicos

        /// <summary>
        /// Realiza o insert do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser inserido</param>
        /// <returns>Objeto Inserido</returns>
        public Questionario Insert(Questionario pObject)
        {
            QuestionarioDAO.BeginTransaction();
            try
            {
                Questionario QuestionarioAux = QuestionarioDAO.InsertByStoredProcedure(pObject);
                pObject.idQuestionario = QuestionarioAux.idQuestionario;

                QuestionarioDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                QuestionarioDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza o update do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atualizado</param>
        /// <returns>Objeto Atualizado</returns>
        public Questionario Update(Questionario pObject)
        {
            QuestionarioDAO.BeginTransaction();
            try
            {
                QuestionarioDAO.UpdateByStoredProcedure(pObject);

                QuestionarioDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                QuestionarioDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza a deleção do objeto por stored Procedure
        /// </summary>
        /// <param name="pidQuestionario">PK da tabela</param>
        /// <returns>Quantidade de Registros deletados</returns>
        public int Delete(int pidQuestionario)
        {
            int iRetorno = 0;
            QuestionarioDAO.BeginTransaction();
            try
            {
                iRetorno = QuestionarioDAO.DeleteByStoredProcedure(pidQuestionario, false, objectSecurity.UserSystem);
                QuestionarioDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                QuestionarioDAO.RollbackTransaction();
                throw ex;
            }
            return iRetorno;
        }

        /// <summary>
        /// Retorna registro pela PK
        /// </summary>
        /// <param name="pidQuestionario">PK da tabela</param>
        /// <returns>Registro da PK</returns>
        public Questionario SelectByPK(int pidQuestionario)
        {
            return QuestionarioDAO.SelectByPK(pidQuestionario);
        }

        /// <summary>
        /// Realiza a busca Lookup
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atribuidos no filtro</param>
        /// <returns>Lista de Objetos que atendam ao filtro</returns>
        public IList<Questionario> ListForLookup(Questionario pObject)
        {
            return QuestionarioDAO.ListForLookup(pObject);
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
        public IList<Questionario> ListForGrid(Questionario pObject, int pNumRegPag, int pNumPagina, string pDesOrdem, out int pNumTotReg)
        {
            return QuestionarioDAO.ListForGrid(pObject, pNumRegPag, pNumPagina, pDesOrdem, out pNumTotReg);
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
                QuestionarioDAO = null;

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

