﻿using AutoMapper;
using FanturApp.Business.Interfaces;
using FanturApp.CrossCutting.Dtos;
using FanturApp.CrossCutting.Models;
using Microsoft.AspNetCore.Mvc;

namespace FanturApp.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageBusiness _packageBusiness;
        private readonly IMapper _mapper;

        public PackageController(IPackageBusiness packageBusiness, IMapper mapper)
        {
            _packageBusiness = packageBusiness;
            _mapper = mapper;
        }

        [HttpGet("GetPackagesWithServices")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Package>))]
        public IActionResult GetPackagesWithServices()
        {
            //var packages = _mapper.Map<List<PackageDto>>(_packageBusiness.GetPackages());
            var packages = _mapper.Map<List<PackageWithServiceDto>>(_packageBusiness.GetPackages());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(packages);
        }



        [HttpGet("{packageId}")]
        [ProducesResponseType(200, Type = typeof(Package))]
        [ProducesResponseType(400)]
        public IActionResult GetPackage(int packageId)
        {
            if (!_packageBusiness.PackageExists(packageId))
                return NotFound();

            var package = _mapper.Map<PackageDto>(_packageBusiness.GetPackage(packageId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(package);
        }

        [HttpGet("{packageId}/services")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Service>))]
        [ProducesResponseType(400)]
        public IActionResult GetServicesByPackage(int packageId)
        {
            if (!_packageBusiness.PackageExists(packageId))
                return NotFound();

            var services = _mapper.Map<List<ServiceDto>>(_packageBusiness.GetServicesByPackage(packageId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(services);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePackage([FromQuery] List<int> serviceid, [FromBody] PackageDto packageCreate)
        {
            if (packageCreate == null)
                return BadRequest(ModelState);

            var package = _packageBusiness.GetPackages()
                .Where(u => u.Name.Trim().ToUpper() == packageCreate.Name.Trim().ToUpper())
                .FirstOrDefault();

            if (package != null)
            {
                ModelState.AddModelError("", "Package name taken");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var packageMap = _mapper.Map<Package>(packageCreate);

            if (!_packageBusiness.CreatePackage(serviceid, packageMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Package successfully created");

        }

        [HttpPatch("{packageId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePackage(int packageId, [FromQuery] List<int> serviceId, [FromBody] PackageDto updatedPackage)
        {
            if (updatedPackage == null)
                return BadRequest(ModelState);

            if (packageId != updatedPackage.Id)
                return BadRequest(ModelState);

            if (!_packageBusiness.PackageExists(packageId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();



            var packageMap = _mapper.Map<Package>(updatedPackage);

            if (!_packageBusiness.UpdatePackage(serviceId, packageMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();



        }
    }
}
