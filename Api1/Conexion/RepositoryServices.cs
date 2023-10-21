using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace Api1.Conexion
{
    public class RepositoryServices:IRepositoryServices
    {
        private readonly IConfiguration _configuration;
        string _error;

        public RepositoryServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string error => _error;

        public async Task Ejecutar(string query, DynamicParameters sp_params, string conection, CommandType commandType = CommandType.StoredProcedure)
        {

            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(conection));

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();
            using var transaction = dbConnection.BeginTransaction();
            try
            {
                await dbConnection.ExecuteAsync(query, sp_params, commandType: commandType, transaction: transaction);
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }

        }

        /// <summary>
        /// traemos el primer registro de la base de datos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="sp_params"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<T> First<T>(string query, DynamicParameters sp_params, string conection, CommandType commandType = CommandType.StoredProcedure)
        {
            try
            {
                using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(conection));
                return await dbConnection.QueryFirstOrDefaultAsync<T>(query, sp_params, commandType: commandType);
            }
            catch (Exception)
            {
                throw;
            }


        }

        /// <summary>
        /// traemos registros de la base de datos pasandole parametros 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="sp_params"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetSPwithParams<T>(string query, DynamicParameters sp_params, string conection, CommandType commandType = CommandType.StoredProcedure)
        {
            try
            {
                using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(conection));
                return await dbConnection.QueryAsync<T>(query, sp_params, commandType: commandType);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// traemos registros de la base de datos sin pasarle parametros 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetSP<T>(string query, string conection, CommandType commandType = CommandType.StoredProcedure)
        {
            try
            {
                using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(conection));
                return await dbConnection.QueryAsync<T>(query, commandType: commandType);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
