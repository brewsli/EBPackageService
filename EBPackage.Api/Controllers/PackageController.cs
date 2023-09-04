using EBPackage.Entities.DataContract.Models;
using EBPackage.Entities.DataContract.Requests;
using EBPackage.Entities.Exceptions;
using EBPackage.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EBPackage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService packageService;
        public PackageController(IPackageService packageService)
        {
            this.packageService = packageService;
        }

        [HttpGet]
        public ActionResult<List<Package>> Get()
        {
            return packageService.GetAllPackages();
        }

        [HttpGet("{kolliId}")]
        public ActionResult<Package?> Get(string kolliId)
        {
            try
            {
                return packageService.GetPackageByKolliId(kolliId);
            }
            catch (WongInputException e)
            {
                return UnprocessableEntity(e.ToString());
            }
            catch (Exception e)
            {
                return StatusCode(500, "An unexpected error occured: " + e.ToString());
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] PackageRequest packageRequest)
        {
            try
            {
                packageService.AddPackage(packageRequest);
                if (!packageRequest.IsValid)
                {
                    return UnprocessableEntity("The package size exceeds the limitations");
                }
            }
            catch (WongInputException e)
            {
                return UnprocessableEntity(e.ToString());
            }
            catch (Exception e)
            {
                return StatusCode(500, "An unexpected error occured: " + e.ToString());
            }
            return Ok("Package added successfully");
        }
    }
}
