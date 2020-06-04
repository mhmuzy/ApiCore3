using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Presentation.Api.Repositories;

namespace Projeto.Presentation.Api.Models.Responses
{
    public class ExclusaoClienteResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ClienteEntity Data { get; set; }
    }
}
