using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEntregas.Data;
using WebApiEntregas.Models;

namespace WebApiEntregas.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class DeliveryController : ControllerBase
    {

        private readonly ILogger<DeliveryController> _logger;
        private readonly AppDbContext _context;

        public DeliveryController(ILogger<DeliveryController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            this._context = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var consult = await _context.Deliveries.ToListAsync();

            if (!consult.Any())
                return NotFound();
           
            return Ok(consult);
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var delivery = await _context.Deliveries.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (delivery is null)
                return NotFound("Registro não encontrado na base de dados.");

            return Ok(delivery);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Delivery delivery)
        {
            
            await _context.Deliveries.AddAsync(delivery);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetId), new { id = delivery.Id }, delivery);
        }

        [HttpPut]
        [Route("/{id}")]
        public async Task<IActionResult> Update([FromBody] Delivery delivery, int id)
        {
            var deliveryBanco = await _context.Deliveries.Where(p => p.Id == id).FirstOrDefaultAsync();

            if (deliveryBanco is null)
                return NotFound("Registro não encontrado na base de dados.");


            deliveryBanco.SetDeliveryNumber(delivery.NumeroDaEntrega);
            deliveryBanco.SetDeliveryData(delivery.DataDaEntrega);


            _context.Deliveries.Update(deliveryBanco);
            _context.SaveChanges();

            return Ok("Registro atualizado com sucesso.");

        }


        [HttpDelete]
        [Route("/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deliveryBanco = await _context.Deliveries.Where(p => p.Id == id).FirstOrDefaultAsync();

            if (deliveryBanco == null)
                return NotFound("Registro não encontrado na base de dados.");

            _context.Deliveries.Remove(deliveryBanco);
            _context.SaveChanges();

            return Ok("Registro deletado com sucesso!");
        }

    }
}