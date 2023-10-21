using Api1.Dtos;
using Api1.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [Route("Principal")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {
        private readonly IProcedures _procedures;

        public PrincipalController(IProcedures procedures)
        {
            _procedures = procedures;
        }

        [HttpGet]
        [Route("obtiene-cliente-id/{id}")]

        public Task<CustomerDto> GetCustomerWithId(int id)
        {
            try
            {
                var datos = _procedures.GetCustomerWithId(id);
                return datos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("obtiene-cliente")]
        public Task<IEnumerable<CustomerDto>> GetCustomer()
        {
            try
            {
                var datos = _procedures.GetAllCustomer();
                return datos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
