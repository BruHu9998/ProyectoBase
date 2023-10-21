using Api1.Dtos;

namespace Api1.Helpers
{
    public interface IProcedures
    {
        /// <summary>
        /// Obtiene los clientes a traves de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<CustomerDto> GetCustomerWithId(int id);

        /// <summary>
        /// Obtiene los clientes 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<CustomerDto>> GetAllCustomer();
    }
}
