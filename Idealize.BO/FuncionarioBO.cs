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
    /// Classe de Negocios da Tabela Funcionario
    /// </summary>
    public class FuncionarioBO : IBaseBO<Funcionario, int>
    {

        #region Variaveis Locais
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected FuncionarioDAO FuncionarioDAO;
        /// <summary>
        /// Objeto de segurança
        /// </summary>
        protected ObjectSecurity objectSecurity;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma instância da classe. Cria uma nova conexao com o banco de dados
        /// </summary>
        public FuncionarioBO(ObjectSecurity pObjectSecurity) : base()
        {
            FuncionarioDAO = new FuncionarioDAO(ConnectionFactory.GetDbConnectionDefault(), pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Inicializa uma instância da classe. Recebendo como parametro a conexao com banco de dados
        /// </summary>
        public FuncionarioBO(System.Data.IDbConnection pIDbConnection, ObjectSecurity pObjectSecurity) : base()
        {
            FuncionarioDAO = new FuncionarioDAO(pIDbConnection, pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="FuncionarioBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~FuncionarioBO()
        {
            FuncionarioDAO.Dispose();
        }

        #endregion

        #region WOLI - Métodos Básicos

        /// <summary>
        /// Realiza o insert do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser inserido</param>
        /// <returns>Objeto Inserido</returns>
        public Funcionario Insert(Funcionario pObject)
        {
            FuncionarioDAO.BeginTransaction();
            try
            {
                Funcionario FuncionarioAux = FuncionarioDAO.InsertByStoredProcedure(pObject);
                pObject.idFuncionario = FuncionarioAux.idFuncionario;

                FuncionarioDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                FuncionarioDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza o update do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atualizado</param>
        /// <returns>Objeto Atualizado</returns>
        public Funcionario Update(Funcionario pObject)
        {
            FuncionarioDAO.BeginTransaction();
            try
            {
                FuncionarioDAO.UpdateByStoredProcedure(pObject);

                FuncionarioDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                FuncionarioDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza a deleção do objeto por stored Procedure
        /// </summary>
        /// <param name="pidFuncionario">PK da tabela</param>
        /// <returns>Quantidade de Registros deletados</returns>
        public int Delete(int pidFuncionaro)
        {
            int iRetorno = 0;
            FuncionarioDAO.BeginTransaction();
            try
            {
                iRetorno = FuncionarioDAO.DeleteByStoredProcedure(pidFuncionario, false, objectSecurity.UserSystem);
                FuncionarioDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                FuncionarioDAO.RollbackTransaction();
                throw ex;
            }
            return iRetorno;
        }

        /// <summary>
        /// Retorna registro pela PK
        /// </summary>
        /// <param name="pidFuncionario">PK da tabela</param>
        /// <returns>Registro da PK</returns>
        public Funcionario SelectByPK(int pidFuncionario)
        {
            return FuncionarioDAO.SelectByPK(pidFuncionario);
        }

        /// <summary>
        /// Realiza a busca Lookup
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atribuidos no filtro</param>
        /// <returns>Lista de Objetos que atendam ao filtro</returns>
        public IList<Funcionario> ListForLookup(Funcionario pObject)
        {
            return FuncionarioDAO.ListForLookup(pObject);
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
        public IList<Funcionario> ListForGrid(Funcionario pObject, int pNumRegPag, int pNumPagina, string pDesOrdem, out int pNumTotReg)
        {
            return FuncionarioDAO.ListForGrid(pObject, pNumRegPag, pNumPagina, pDesOrdem, out pNumTotReg);
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
                FuncionarioDAO = null;

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

