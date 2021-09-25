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
    public class StatusLaserController : Controller
    {
        private readonly ILogger<StatusLaserController> _logg;
        public string serviceName = "";
        IConfiguration _config;
        ServiceController svcController;
        public StatusLaserController(ILogger<StatusLaserController> logg, IConfiguration config)
        {
            _logg = logg;
            _config = config;
            serviceName = _config.GetValue<string>("ServiceName");
            svcController = new ServiceController(serviceName);
        }

        [HttpGet]
        public string GetStatus()
        {
            return svcController.Status.ToString();
        }
    }
}
