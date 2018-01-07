﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KnownProblemApi.Models;

namespace KnownProblemApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Resolve")]
    public class ResolveController : Controller
    {
        [HttpPost]
        public IActionResult Resolve([FromBody]ProblemSolved solution)
        {
            return NoContent();
        }
    }
}