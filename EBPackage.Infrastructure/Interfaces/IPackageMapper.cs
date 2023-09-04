using EBPackage.Entities.DataContract.Models;
using EBPackage.Entities.DataContract.Requests;

namespace EBPackage.Infrastructure.Interfaces
{
    public interface IPackageMapper
    {
        Package Create(PackageRequest packageRequest);
    }
}
