using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ex1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;
        private readonly IMapper mapper;
        public ProductsController(IProductService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get( string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoriesId)
        {
            IEnumerable<Product> products= await service.getAllProduct( desc,  minPrice,  maxPrice, categoriesId);
            IEnumerable<ProductDTO> productsDTO = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return Ok(productsDTO);
        }

 





    }
}
