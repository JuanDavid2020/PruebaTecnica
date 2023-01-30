using Microsoft.AspNetCore.Mvc;
using NetcoreAPIMySQL.Data.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using NetCoreAPIMySQL.Model;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.Extensions.Logging;


namespace NetCorePrueba.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Gestion de descuentos")]
    public class DiscountsController : ControllerBase
    {

        private readonly IDiscountsRepository _discountsRepository;

        public DiscountsController(IDiscountsRepository discountsRepository)
        {
            _discountsRepository = discountsRepository;

        }

        [Route("/GetDiscounts")]
        [HttpGet]
        
        public  async Task<IActionResult> Getdiscounts()
        {
            var resultado = await _discountsRepository.GetDiscounts();

            return Ok(resultado);
    
        }

        [Route("/GetDescuento")]
        [HttpGet]

        public async Task<IActionResult> GetdiscountsDetails(int id)
        {
            return Ok(await _discountsRepository.GetDiscountsDetails(id));
        }


        [Route("/InsertDiscounts")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Insertdiscounts([FromBody] Discounts discounts)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = Jwt.validateToken(identity);

            if (discounts == null)

                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Created("0K",await _discountsRepository.InsertDiscounts(discounts));
        }

        [Route("/UpdateDiscounts")]
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Updatediscounts([FromBody] Discounts discounts)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = Jwt.validateToken(identity);

            if (discounts == null)

                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Created("0K", await _discountsRepository.UpdateDiscounts(discounts));
        }

        [Route("/DeleteDiscounts")]
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Deletediscounts(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = Jwt.validateToken(identity);

            return Created("0K", await _discountsRepository.DeleteDiscounts(new Discounts() { Id = id }));
        }

    }
}
