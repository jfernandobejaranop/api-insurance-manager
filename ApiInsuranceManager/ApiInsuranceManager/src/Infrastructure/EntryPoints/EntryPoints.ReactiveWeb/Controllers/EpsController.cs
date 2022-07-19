using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using credinet.comun.api;
using Domain.UseCase;
using Domain.Model.Entities;
using static credinet.comun.negocio.RespuestaNegocio<credinet.exception.middleware.models.ResponseEntity>;
using static credinet.exception.middleware.models.ResponseEntity;
using System;
using Microsoft.Extensions.Logging;
using Domain.UseCase.Interface;

namespace EntryPoints.ReactiveWeb.Controllers
{
    /// <summary>
    /// EntityController
    /// </summary>
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    public class EpsController : BaseController<EpsController>
    {
        private readonly IEntityEPS _eps;
        private readonly ILogger<EpsController> _logger;

        /// <summary>
        /// Build
        /// </summary>
        /// <param name="eps"></param>
        public EpsController(IEntityEPS eps, ILogger<EpsController> logger)
        {
            _logger = logger;
            this._eps = eps;
        }

        /// <summary>
        /// Obtiene todos los objetos de tipo <see cref="Entity"/>
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna la lista</response>
        /// <response code="400">Si existe algun problema al consultar</response>
        /// <response code="406">Si no se envia el ambiente correcto</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Entity>))]
        public async Task<IActionResult> GetAll()
        {
            var respuestaNegocio = await _eps.GetAllEPS();
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }
    }
}

