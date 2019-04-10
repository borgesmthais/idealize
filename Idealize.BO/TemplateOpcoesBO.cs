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
    /// Classe de Negocios da Tabela TemplateOpcoes
    /// </summary>
    public class TemplateOpcoesBO : IBaseBO<TemplateOpcoes, int>
    {

        #region Variaveis Locais
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected TemplateOpcoesDAO TemplateOpcoesDAO;
        /// <summary>
        /// Objeto de segurança
        /// </summary>
        protected ObjectSecurity objectSecurity;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma instância da classe. Cria uma nova conexao com o banco de dados
        /// </summary>
        public TemplateOpcoesBO(ObjectSecurity pObjectSecurity) : base()
        {
            TemplateOpcoesDAO = new TemplateOpcoesDAO(ConnectionFactory.GetDbConnectionDefault(), pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Inicializa uma instância da classe. Recebendo como parametro a conexao com banco de dados
        /// </summary>
        public TemplateOpcoesBO(System.Data.IDbConnection pIDbConnection, ObjectSecurity pObjectSecurity) : base()
        {
            TemplateOpcoesDAO = new TemplateOpcoesDAO(pIDbConnection, pObjectSecurity);
            objectSecurity = pObjectSecurity;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the <see cref="TemplateOpcoesBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~TemplateOpcoesBO()
        {
            TemplateOpcoesDAO.Dispose();
        }

        #endregion

        #region WOLI - Métodos Básicos

        /// <summary>
        /// Realiza o insert do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser inserido</param>
        /// <returns>Objeto Inserido</returns>
        public TemplateOpcoes Insert(TemplateOpcoes pObject)
        {
            TemplateOpcoesDAO.BeginTransaction();
            try
            {
                TemplateOpcoes TemplateOpcoesAux = TemplateOpcoesDAO.InsertByStoredProcedure(pObject);
                pObject.idTemplateOpcao = TemplateOpcoesAux.idTemplateOpcao;

                TemplateOpcoesDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                TemplateOpcoesDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza o update do objeto por stored Procedure
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atualizado</param>
        /// <returns>Objeto Atualizado</returns>
        public TemplateOpcoes Update(TemplateOpcoes pObject)
        {
            TemplateOpcoesDAO.BeginTransaction();
            try
            {
                TemplateOpcoesDAO.UpdateByStoredProcedure(pObject);

                TemplateOpcoesDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                TemplateOpcoesDAO.RollbackTransaction();
                throw ex;
            }
            return pObject;
        }

        /// <summary>
        /// Realiza a deleção do objeto por stored Procedure
        /// </summary>
        /// <param name="pidTemplateOpcao">PK da tabela</param>
        /// <returns>Quantidade de Registros deletados</returns>
        public int Delete(int pidTemplateOpcao)
        {
            int iRetorno = 0;
            TemplateOpcoesDAO.BeginTransaction();
            try
            {
                iRetorno = TemplateOpcoesDAO.DeleteByStoredProcedure(pidTemplateOpcao, false, objectSecurity.UserSystem);
                TemplateOpcoesDAO.CommitTransaction();
            }
            catch (Exception ex)
            {
                TemplateOpcoesDAO.RollbackTransaction();
                throw ex;
            }
            return iRetorno;
        }

        /// <summary>
        /// Retorna registro pela PK
        /// </summary>
        /// <param name="pidTemplateOpcao">PK da tabela</param>
        /// <returns>Registro da PK</returns>
        public TemplateOpcoes SelectByPK(int pidTemplateOpcao)
        {
            return TemplateOpcoesDAO.SelectByPK(pidTemplateOpcao);
        }

        /// <summary>
        /// Realiza a busca Lookup
        /// </summary>
        /// <param name="pObject">Objeto com os valores a ser atribuidos no filtro</param>
        /// <returns>Lista de Objetos que atendam ao filtro</returns>
        public IList<TemplateOpcoes> ListForLookup(TemplateOpcoes pObject)
        {
            return TemplateOpcoesDAO.ListForLookup(pObject);
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
        public IList<TemplateOpcoes> ListForGrid(TemplateOpcoes pObject, int pNumRegPag, int pNumPagina, string pDesOrdem, out int pNumTotReg)
        {
            return TemplateOpcoesDAO.ListForGrid(pObject, pNumRegPag, pNumPagina, pDesOrdem, out pNumTotReg);
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
                TemplateOpcoesDAO = null;

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