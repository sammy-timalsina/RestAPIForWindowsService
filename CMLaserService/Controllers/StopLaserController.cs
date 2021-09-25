using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace CMLaserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StopLaserController : Controller
    {
        private readonly ILogger<StopLaserController> _logg;
        public string serviceName = "";
        IConfiguration _config;
        ServiceController svcController;
        public StopLaserController(ILogger<StopLaserController> logg, IConfiguration config)
        {
            _logg = logg;
            _config = config;
            serviceName = _config.GetValue<string>("ServiceName");
            svcController = new ServiceController(serviceName);
        }
        [HttpGet]
        public string StopService()
        {
            svcController.Stop();

            return svcController.Status.ToString();
        }
    }
}
