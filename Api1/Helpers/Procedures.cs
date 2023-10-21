using Api1.Conexion;
using Api1.Dtos;
using Dapper;
using System.Data;
namespace Api1.Helpers
{
    public class Procedures:IProcedures
    {
        private readonly IConfiguration _configuration;
        private readonly IRepositoryServices _repositoryServices;
        string conexion= "SqlConnection";
        public  Procedures(IConfiguration configuration,IRepositoryServices repositoryServices)
        {
            _configuration = configuration;
            _repositoryServices = repositoryServices;
        }

        public Task<CustomerDto> GetCustomerWithId(int id)
        {
            try
            {
                var query = "dbo.sp_GetCustomer";
                DynamicParameters param = new DynamicParameters();
                param.Add("@idCliente", id, DbType.Int64);
                var respuesta = _repositoryServices.First<CustomerDto>(query, param, conexion);
                return respuesta; 
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public Task<IEnumerable<CustomerDto>> GetAllCustomer()
        {
            try
            {
                var query = "dbo.sp_GetCustomer";
                var respuesta = _repositoryServices.GetSP<CustomerDto>(query, conexion);
                return respuesta;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
