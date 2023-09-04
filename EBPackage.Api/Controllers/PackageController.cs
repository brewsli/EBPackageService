using EBPackage.Entities.DataContract.Models;
using EBPackage.Entities.DataContract.Requests;
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
        public ActionResult<Package> Get(string kolliId)
        {
            return packageService.GetPackageByKolliId(kolliId);
        }

        [HttpPost]
        public ActionResult Post([FromBody] PackageRequest packageRequest)
        {
            try
            {
                packageRequest.Validate();
                packageService.AddPackage(packageRequest);
                if (!packageRequest.IsValid)
                {
                    return UnprocessableEntity("The package size exceeds the limitations");
                }
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
            return Ok();
        }
    }
}
