using EBPackage.Entities.DataContract.Models;

namespace EBPackage.Database
{
    public static class PackageDatabase
    {
        private static List<Package> packages = new List<Package>()
        {
            new Package()
            {
                Width = 200,
                Length = 200,
                Height = 200,
                Weight = 200,
                KolliId = "99912345678912341",
                IsValid = true,
            },
            new Package()
            {
                Width =  3100,
                Length = 3100,
                Height = 3100,
                Weight = 3100,
                KolliId = "99912345678912342",
                IsValid = false,
            },
            new Package()
            {
                Width =  100,
                Length = 100,
                Height = 100,
                Weight = 100,
                KolliId = "99912345678912343",
                IsValid = true,
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

        public static Package GetPackageByKolliId(string kolliId)
        {
            return packages.FirstOrDefault(p => p.KolliId == kolliId);
        }
    }
}