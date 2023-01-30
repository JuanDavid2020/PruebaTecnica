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
using System.Net;
using System.Text.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace NetCorePrueba.Controllers
{


    /*[SwaggerTag("Pais",
           SwaggerTagAtribute.Description = "Web API para mantenimiento de Países.",
           DocumentationDescription = "Documentación externa",
           DocumentationUrl = "http://rafaelacosta.net/pais-doc.pdf")]*/
    [Route("[controller]")]
    [ApiController]

    public class SalesController : ControllerBase
    {

        private readonly ISalesRepository _salesRepository;

        public SalesController(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;

        }

        
        [HttpGet]
        [Route("GetSales")]

        public async Task<IActionResult> Getsales()
        {
            return Ok(await _salesRepository.GetSales());

        }

       
        [HttpGet]
        [Route("GetSale")]

        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _salesRepository.GetSalesDetails(id));
        }

        [HttpPost]
        [Route("InsertSales")]
        [Authorize]
        public async Task<IActionResult> Insertsales(int QuantityProducts, string DescriptionSale)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = Jwt.validateToken(identity);

            if (QuantityProducts == 0)
            { 
            return BadRequest();
            }

            var created = await _salesRepository.InsertSales(QuantityProducts,DescriptionSale);
            return Ok(created);
        }

        [Route("/SumSales")]
        [HttpGet]

        public async Task<IActionResult> GetSumarsales(string type)
        {
            var resultado = await _salesRepository.SumSales(type);
            return Ok(resultado);

        }


        [Route("/DeleteSale")]
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteSale(int id)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = Jwt.validateToken(identity);
            await _salesRepository.DeleteSales(new Sales() { IdSales = id });
            return NoContent();
        }
    }
}
