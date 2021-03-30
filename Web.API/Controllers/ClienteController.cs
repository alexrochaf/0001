using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Models;
using Web.API.Models.Db;
using Web.API.Servicos.Interfaces;

namespace Web.API.Controllers
{
    [Route("api/clientes")]
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


        [HttpGet("{id}")]
        public ActionResult GetId(int id)
        {
            try
            {
                using (_context = new WebContext())
                {
                    return Ok(_context.Clientes.Find(id));
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("consultar")]
        public async Task<Cliente> ObeterDados(string email)
        {
            return await _servico.ObterDadosPorEmail(email);
        }

        [HttpPost]
        public Result Post(Cliente cliente)
        {
            try
            {
                using (_context = new WebContext())
                {
                    _context.Add(cliente);
                    _context.SaveChanges();
                }

                return new Result(true, "Gravado com sucesso", cliente);
            }
            catch (Exception ex)
            {

                return new Result(false, ex.Message, cliente);
            }
        }

        [HttpPut("{id}")]
        public Result Put(int id, Cliente cliente)
        {
            try
            {
                using (_context = new WebContext())
                {
                    var clienteBase = _context.Clientes.Find(id);

                    clienteBase.Update(cliente);

                    _context.SaveChanges();
                }

                return new Result(true, "Atualizado com sucesso", cliente);
            }
            catch (Exception ex)
            {

                return new Result(false, ex.Message, cliente);
            }
        }

        [HttpDelete("{id}")]
        public Result Delete(int id)
        {
            try
            {
                using (_context = new WebContext())
                {
                    var cliente = _context.Clientes.Find(id);

                    _context.Remove(cliente);

                    _context.SaveChanges();
                }

                return new Result(true, "Removido com sucesso", null);
            }
            catch (Exception ex)
            {

                return new Result(false, ex.Message, null);
            }
        }
    }
}