﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleAppCore.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ApiController : Controller
    {
    }
}