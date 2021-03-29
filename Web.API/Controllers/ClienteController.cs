using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Models.Db;
using Web.API.Servicos.Interfaces;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private WebContext _context = null;
        private readonly IJsonPlaceHolderServico _servico;

        public ClienteController(IJsonPlaceHolderServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                using (_context = new WebContext())
                {
                    var collection = _context.Clientes;
                    return Ok(collection?.ToList());
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObterDados")]
        public async Task<Cliente> ObeterDados(string email)
        {
            return await _servico.ObterDadosPorEmail(email);
        }
    }
}