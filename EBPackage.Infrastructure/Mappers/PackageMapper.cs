using EBPackage.Entities.DataContract.Models;
using EBPackage.Entities.DataContract.Requests;
using EBPackage.Infrastructure.Interfaces;

namespace EBPackage.Infrastructure.Mappers
{
    public class PackageMapper : IPackageMapper
    {
        public Package Create(PackageRequest packageRequest)
        {
            return new Package
            {
                KolliId = packageRequest.KolliId,
                Weight = packageRequest.Weight,
                Length = packageRequest.Length,
                Height = packageRequest.Height,
                Width = packageRequest.Width
            };
        }
    }
}
