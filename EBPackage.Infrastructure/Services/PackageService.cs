using EBPackage.Database;
using EBPackage.Entities.DataContract.Models;
using EBPackage.Entities.DataContract.Requests;
using EBPackage.Infrastructure.Interfaces;

namespace EBPackage.Infrastructure.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageMapper packageMapper;
        public PackageService(IPackageMapper packageMapper)
        {
            this.packageMapper = packageMapper;
        }

        public void AddPackage(PackageRequest packageRequest)
        {
            var package = packageMapper.Create(packageRequest);
            PackageDatabase.AddPackage(package);
        }

        public List<Package> GetAllPackages()
        {
            return PackageDatabase.GetAllPackages();
        }

        public Package GetPackageByKolliId(string kolliId)
        {
            return PackageDatabase.GetPackageByKolliId(kolliId);
        }
    }
}
