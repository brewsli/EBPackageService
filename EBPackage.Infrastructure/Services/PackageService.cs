using EBPackage.Database;
using EBPackage.Entities.DataContract.Models;
using EBPackage.Entities.DataContract.Requests;
using EBPackage.Entities.Exceptions;
using EBPackage.Infrastructure.Interfaces;
using EBPackage.Infrastructure.Validators;

namespace EBPackage.Infrastructure.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageMapper packageMapper;
        public PackageService(IPackageMapper packageMapper)
        {
            this.packageMapper = packageMapper;
        }

        public List<Package> GetAllPackages()
        {
            return PackageDatabase.GetAllPackages();
        }

        public Package? GetPackageByKolliId(string kolliId)
        {
            kolliId.Validate();
            var package = PackageDatabase.GetPackageByKolliId(kolliId);
            return package == null ? throw new WongInputException($"Package with {kolliId} does not exist") : package;
        }

        public void AddPackage(PackageRequest packageRequest)
        {
            packageRequest.Validate();
            if (PackageDatabase.PackagesAlreadyExists(packageRequest.KolliId))
            {
                throw new WongInputException($"Package with {packageRequest.KolliId} already exists");
            }

            var package = packageMapper.Create(packageRequest);
            PackageDatabase.AddPackage(package);
        }
    }
}
