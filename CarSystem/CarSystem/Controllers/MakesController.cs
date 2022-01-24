using CarSystem.Services.Interfaces;
using CarSystem.ViewModels.Makes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.Controllers
{
    public class MakesController : ApiController
    {
        private readonly IMakesService makesService;

        public MakesController(IMakesService makesService)
        {
            this.makesService = makesService;
        }

        [HttpGet]
        [Route(nameof(Get))]
        public ActionResult<MakeViewModel> Get()
        {
            var makes = this.makesService.Get();

            return Ok(makes);
        }
    }
}
