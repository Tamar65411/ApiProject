using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ex1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
       private readonly IOrdersService service;
        private readonly IMapper mapper;
        public OrdersController(IOrdersService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<CreatedAtActionResult> Post([FromBody] OrderDTO orderDTO)
        {


            OrdersTbl order = mapper.Map<OrderDTO, OrdersTbl>(orderDTO); 


            OrdersTbl newOrder = await service.addNewOrder(order);
            if (newOrder == null)
            {
                return null;
            }
            OrderDTO data = mapper.Map< OrdersTbl,OrderDTO>(newOrder);
            return CreatedAtAction(nameof(Get), new { id = data.OrderId }, data);


        }




    }
}
