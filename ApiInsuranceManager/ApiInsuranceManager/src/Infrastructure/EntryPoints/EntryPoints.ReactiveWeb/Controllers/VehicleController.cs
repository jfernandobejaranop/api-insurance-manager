using credinet.comun.api;
using Domain.Model.DTO;
using Domain.Model.Entities;
using Domain.UseCase.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using static credinet.comun.negocio.RespuestaNegocio<credinet.exception.middleware.models.ResponseEntity>;
using static credinet.exception.middleware.models.ResponseEntity;

namespace EntryPoints.ReactiveWeb.Controllers
{
    /// <summary>
    /// EntityController
    /// </summary>
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    public class VehicleController : BaseController<VehicleController>
    {
        private readonly IVehicles _vehicle;
        private readonly ILogger<VehicleController> _logger;

        /// <summary>
        /// Build
        /// </summary>
        /// <param name="eps"></param>
        public VehicleController(IVehicles vehicle, ILogger<VehicleController> logger)
        {
            _logger = logger;
            _vehicle = vehicle;
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
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            var respuestaNegocio = _vehicle.Create(vehicle);
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }


        ///// <summary>
        ///// Obtiene todos los objetos de tipo <see cref="Entity"/>
        ///// </summary>
        ///// <returns></returns>
        ///// <response code="200">Retorna la lista</response>
        ///// <response code="400">Si existe algun problema al consultar</response>
        ///// <response code="406">Si no se envia el ambiente correcto</response>
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(406)]
        //[HttpGet()]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<Entity>))]
        //public async Task<IActionResult> GetLine(int idBrand)
        //{
        //    var respuestaNegocio = await _eps.GetAllEPS();
        //    return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        //}
    }
}

