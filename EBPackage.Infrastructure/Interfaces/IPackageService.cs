using EBPackage.Entities.DataContract.Models;
using EBPackage.Entities.DataContract.Requests;

namespace EBPackage.Infrastructure.Interfaces
{
    public interface IPackageService
    {
        List<Package> GetAllPackages();
        Package GetPackageByKolliId(string kolliId);
        void AddPackage(PackageRequest packageRequest);
    }
}
