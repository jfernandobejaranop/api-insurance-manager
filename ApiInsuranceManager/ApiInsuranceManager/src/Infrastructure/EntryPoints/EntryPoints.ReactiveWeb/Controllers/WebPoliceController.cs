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
using Domain.Model.DTO;

namespace EntryPoints.ReactiveWeb.Controllers
{
    /// <summary>
    /// EntityController
    /// </summary>
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    public class WebPoliceController : BaseController<WebPoliceController>
    {
        private readonly IPoliceWeb _police;
        private readonly ILogger<WebPoliceController> _logger;

        /// <summary>
        /// Build
        /// </summary>
        /// <param name="eps"></param>
        public WebPoliceController(IPoliceWeb police, ILogger<WebPoliceController> logger)
        {
            _logger = logger;
            _police = police;
        }

        /// <summary>
        /// Obtiene todos los objetos de tipo <see cref="Police"/>
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna la lista</response>
        /// <response code="400">Si existe algun problema al consultar</response>
        /// <response code="406">Si no se envia el ambiente correcto</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Police>))]
        public async Task<IActionResult> GetAll()
        {
            var respuestaNegocio = _police.GetAll();
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }


        /// <summary>
        /// Obtiene todos los objetos de tipo <see cref="Police"/>
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna la lista</response>
        /// <response code="400">Si existe algun problema al consultar</response>
        /// <response code="406">Si no se envia el ambiente correcto</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Police>))]
        public async Task<IActionResult> Get(string placa)
        {
            var respuestaNegocio = _police.Get(placa);
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }
    }
}

