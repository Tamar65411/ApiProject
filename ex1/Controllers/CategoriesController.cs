using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ex1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper mapper;
        private ICategoryService service;
        public CategoriesController(ICategoryService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IEnumerable<CategoriesDTO>> Get()
        {

           IEnumerable <Category > categoriesList= await service.getAllCategories();
           IEnumerable<CategoriesDTO> categoriesListDTO = mapper.Map<IEnumerable<Category>, IEnumerable<CategoriesDTO>>(categoriesList);
            return categoriesListDTO;
        }

    }
}
