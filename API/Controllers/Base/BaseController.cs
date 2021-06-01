using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Base
{
    [Produces(MediaTypeNames.Application.Json)]
    public class BaseController : ControllerBase
    {
        protected readonly IMapper Mapper;
        
        public BaseController (IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}