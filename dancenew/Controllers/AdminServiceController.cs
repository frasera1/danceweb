using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dancenew.Data;
using dancenew.Services;

namespace dancenew.Controllers
{
    public class AdminServiceController : ApiController
    {
        private IDanceRepository _dDb;

        public AdminServiceController(IDanceRepository dDb)
        {
            _dDb = dDb;
        }


    }
}
