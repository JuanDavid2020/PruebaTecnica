using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetcoreAPIMySQL.Data.Repositories;
using NetCorePrueba.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TestUintarias
{
    [TestClass]
    public class UnitTest1
    {
        private ISalesRepository salesRepository;

        [TestMethod]
        public async Task Getsales()
        {
            var controller = new SalesController(salesRepository);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            var esperado = HttpStatusCode.OK;
            var respuesta = await controller.Getsales();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(esperado, respuesta);

        }

    }
}




