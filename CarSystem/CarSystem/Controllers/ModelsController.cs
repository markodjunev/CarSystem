using CarSystem.Services.Interfaces;
using CarSystem.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.Controllers
{
    public class ModelsController : ApiController
    {
        private readonly IModelsService modelsService;

        public ModelsController(IModelsService modelsService)
        {
            this.modelsService = modelsService;
        }

        [HttpGet]
        [Route(nameof(Get) + "/{id}")]
        public ActionResult<ModelViewModel> Get(int id)
        {
            var models = this.modelsService.GetByMakeId(id);

            return Ok(models);
        }
    }
}
