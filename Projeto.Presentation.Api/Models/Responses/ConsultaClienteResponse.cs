using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Presentation.Api.Repositories;

namespace Projeto.Presentation.Api.Models.Responses
{
    public class ConsultaClienteResponse
    {
        public int StatusCode { get; set; }
        public List<ClienteEntity> Data { get; set; }
    }
}
