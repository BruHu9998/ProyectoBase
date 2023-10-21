using Dapper;
using System.Data;

namespace Api1.Conexion
{
    public interface IRepositoryServices
    {
        /// <summary>
        /// ejecucion
        /// </summary>
        /// <param name="query"></param>
        /// <param name="sp_params"></param>
        /// <param name="conection"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Task Ejecutar(string query, DynamicParameters sp_params, string conection, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Se muestra el primer registro obtenido
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="sp_params"></param>
        /// <param name="conection"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Task<T> First<T>(string query, DynamicParameters sp_params, string conection, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Obtener datos con parametros
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="sp_params"></param>
        /// <param name="conection"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Task<IEnumerable<T>> GetSPwithParams<T>(string query, DynamicParameters sp_params, string conection, CommandType commandType = CommandType.StoredProcedure);


        /// <summary>
        /// Obtener Datos sin parametros
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="conection"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Task<IEnumerable<T>> GetSP<T>(string query, string conection, CommandType commandType = CommandType.StoredProcedure);
    }
}
