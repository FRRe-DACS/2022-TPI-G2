using AutoMapper;
using FanturApp.Business.Interfaces;
using FanturApp.CrossCutting.Dtos;
using FanturApp.CrossCutting.Models;
using Microsoft.AspNetCore.Mvc;

namespace FanturApp.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceBusiness _serviceBusiness;
        private readonly IMapper _mapper;

        public ServiceController(IServiceBusiness serviceBusiness, IMapper mapper)
        {
            _serviceBusiness = serviceBusiness;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Service>))]
        public IActionResult GetServices()
        {
            var services = _mapper.Map<List<ServiceDto>>(_serviceBusiness.GetServices());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(services);
        }

        [HttpGet("GetServiceCategories")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ServiceCategory>))]
        public IActionResult GetSeviceCategories()
        {
            var categories = _serviceBusiness.GetServiceCategories();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(categories);
        }

        [HttpGet("{serviceId}")]
        [ProducesResponseType(200, Type = typeof(Service))]
        [ProducesResponseType(400)]
        public IActionResult GetService(int serviceId)
        {
            if (!_serviceBusiness.ServiceExists(serviceId))
                return NotFound();

            var service = _mapper.Map<ServiceDto>(_serviceBusiness.GetService(serviceId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(service);
        }

        [HttpGet("{serviceId}/packages")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Package>))]
        [ProducesResponseType(400)]
        public IActionResult GetPackagesByService(int serviceId)
        {
            if (!_serviceBusiness.ServiceExists(serviceId))
                return NotFound();

            var packages = _mapper.Map<List<PackageDto>>(_serviceBusiness.GetPackagesByService(serviceId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(packages);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateService([FromQuery] int categoryid, [FromBody] ServiceDto serviceCreate)
        {
            if (serviceCreate == null)
                return BadRequest(ModelState);

            var service = _serviceBusiness.GetServices()
                .Where(u => u.Description.Trim().ToUpper() == serviceCreate.Description.Trim().ToUpper())
                .FirstOrDefault();

            if (service != null)
            {
                ModelState.AddModelError("", "Service name already exist taken");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var serviceMap = _mapper.Map<Service>(serviceCreate);

            serviceMap.Category = _serviceBusiness.GetCategory(categoryid);

            if (!_serviceBusiness.CreateService(serviceMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Service successfully created");

        }

        [HttpPut("{serviceId}")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateService(int serviceId, [FromBody] ServiceDto updatedService)
        {
            if (updatedService == null)
                return BadRequest(ModelState);

            if (serviceId != updatedService.Id)
                return BadRequest(ModelState);

            if (!_serviceBusiness.ServiceExists(serviceId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var serviceMap = _mapper.Map<Service>(updatedService);

            if (!_serviceBusiness.UpdateService(serviceMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();



        }


        [HttpDelete("{serviceId}")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteService(int serviceId)
        {

            if (!_serviceBusiness.ServiceExists(serviceId))
                return NotFound();


            var serviceToDelete = _serviceBusiness.GetService(serviceId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_serviceBusiness.DeleteService(serviceToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
            }

            return NoContent();



        }



    }
}
