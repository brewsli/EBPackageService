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
        public ActionResult<List<string>> Get()
        {
            return new List<string>() { "Package 1", "Package 2" };
        }

        [HttpGet("{kolliId}")]
        public ActionResult<string> Get(string kolliId)
        {
            return "Package 1";
        }

        [HttpPost]
        public void Post([FromBody] PackageRequest packageRequest)
        {

        }
    }
}
