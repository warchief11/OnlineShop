using ParkAssist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParkAssist.Controllers.api
{
    public abstract class BaseAPIController : ApiController
    {
        protected IOrderService _orderService;

        protected BaseAPIController(IOrderService orderService)
        {
            _orderService = orderService;
        }

    }
}
