using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Presentation.Api.Models.Requests;
using Projeto.Presentation.Api.Models.Responses;
using Projeto.Presentation.Api.Repositories;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        //atributo
        private readonly ClienteRepository clienteRepository;

        //construtor para injeção de dependência
        public ClientesController(ClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CadastroClienteResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(CadastroClienteRequest request)
        {
            var entity = new ClienteEntity
            { 
                IdCliente = new Random().Next(999, 999999),
                Nome = request.Nome,
                Email = request.email,
                Cpf = request.cpf,
                DataCriacao = DateTime.Now
            };

            clienteRepository.Add(entity);

            var response = new CadastroClienteResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Cliente cadastrado com sucesso.",
                Data = entity
            };
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EdicaoClienteResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(EdicaoClienteRequest request)
        {
            var entity = clienteRepository.GetById(request.IdCliente);

            //verificando se o cliente não foi encontrado
            if (entity == null)
                return UnprocessableEntity();

            entity.Nome = request.Nome;
            entity.Email = request.Email;
            entity.Cpf = request.Cpf;

            var response = new EdicaoClienteResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Cliente atualizado com sucesso.",
                //Data = entity
            }; 
                
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExclusaoClienteResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            var entity = clienteRepository.GetById(id);

            //verificando se  o cliente não foi encontrado
            if (entity == null)
                return UnprocessableEntity();

            clienteRepository.Remove(entity);

            var response = new ExclusaoClienteResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Cliente excluido com sucesso.",
                //Data = entity
            };
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new ConsultaClienteResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                //Data = clienteRepository.GetAll()
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            var response = new ConsultaClienteResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = new List<ClienteEntity>()
            };

            response.Data.Add(clienteRepository.GetById(id));

            return Ok(response);
        }
    }
}
