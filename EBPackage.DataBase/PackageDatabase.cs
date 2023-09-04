using EBPackage.Entities.DataContract.Models;

namespace EBPackage.Database
{
    public static class PackageDatabase
    {
        private static List<Package> packages = new List<Package>()
        {
            new Package()
            {
                Width = 15,
                Length = 18,
                Height = 16,
                Weight = 1999,
                KolliId = "999123456789123451",
            },
            new Package()
            {
                Width =  10,
                Length = 10,
                Height = 10,
                Weight = 1000,
                KolliId = "999123456789123452",
            },
            new Package()
            {
                Width =  22,
                Length = 33,
                Height = 44,
                Weight = 5555,
                KolliId = "999123456789123453",
            },
            new Package()
            {
                Width =  100,
                Length = 100,
                Height = 100,
                Weight = 3000,
                KolliId = "999123456789123454",
            }
        };

        public static void AddPackage(Package package)
        {
            packages.Add(package);
        }

        public static List<Package> GetAllPackages()
        {
            return packages;
        }

        public static Package? GetPackageByKolliId(string kolliId)
        {
            return packages.FirstOrDefault(p => p.KolliId == kolliId);
        }

        public static bool PackagesAlreadyExists(string kolliId)
        {
            return GetPackageByKolliId(kolliId) != null;
        }
    }
}