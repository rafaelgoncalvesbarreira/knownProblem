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
    [Route("api/Duplicate")]
    public class DuplicateController : Controller
    {
        [HttpPost]
        public IEnumerable<ProblemDuplication> GetDuplication(int id)
        {
            return null;
        }

        [HttpPost]
        public IActionResult Duplicated([FromBody]ProblemDuplication duplication)
        {
            return NoContent();
        }
    }
}