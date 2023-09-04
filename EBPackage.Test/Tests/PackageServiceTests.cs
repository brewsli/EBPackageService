using EBPackage.Entities.DataContract.Models;
using EBPackage.Entities.DataContract.Requests;
using EBPackage.Entities.Exceptions;
using EBPackage.Infrastructure.Interfaces;
using EBPackage.Infrastructure.Services;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace EBPackage.Test.Tests
{
    public class PackageServiceTests
    {
        private readonly PackageService packageService;
        public PackageServiceTests()
        {
            packageService = new PackageService(Substitute.For<IPackageMapper>());
        }

        [Fact]
        public void GetAllPackages_Returns_List_Of_Packages()
        {
            var allPackages = packageService.GetAllPackages();

            Assert.NotNull(allPackages);
            Assert.IsType<List<Package>>(allPackages);
        }

        [Theory]
        [InlineData("999123456789123451")]
        [InlineData("999123456789123452")]
        [InlineData("999123456789123453")]
        [InlineData("999123456789123454")]
        public void GetPackageByKolliId_With_Correct_KolliId_Returns_Package(string kolliId)
        {
            var allPackages = packageService.GetPackageByKolliId(kolliId);

            Assert.NotNull(allPackages);
            Assert.IsType<Package>(allPackages);
        }

        [Theory]
        [InlineData("99A923456789123451")]
        [InlineData("991123456789123452")]
        [InlineData("99912345678912345")]
        [InlineData("999123456789123450")]
        [InlineData("12345")]
        public void GetPackageByKolliId_With_InCorrect_KolliId_Throws_Exception(string kolliId)
        {
            Assert.Throws<WongInputException>(() => packageService.GetPackageByKolliId(kolliId));
        }

        [Fact]
        public void Add_Package_With_Incorrect_Request_Throws_Exception()
        {
            var mockedPackageRequests = GetMockedPackageRequests();

            foreach (var mockedPackageRequest in mockedPackageRequests)
            {
                Assert.Throws<WongInputException>(() => packageService.AddPackage(mockedPackageRequest));
            }
        }

        private List<PackageRequest> GetMockedPackageRequests()
        {
            return new List<PackageRequest>() 
            { 
                new PackageRequest() 
                { 
                    KolliId = "123", 
                    Height = 10, 
                    Length = 10, 
                    Width = 10, 
                    Weight = 20 
                },
                new PackageRequest()
                {
                    KolliId = "999123123123123123",
                    Height = -1,
                    Length = 10,
                    Width = 10,
                    Weight = 20
                },
                new PackageRequest()
                {
                    KolliId = "999123123123123123",
                    Height = 10,
                    Length = -1,
                    Width = 10,
                    Weight = 20
                },
                new PackageRequest()
                {
                    KolliId = "999123123123123123",
                    Height = 10,
                    Length = 20,
                    Width = -1,
                    Weight = 20
                },
                new PackageRequest()
                {
                    KolliId = "999123123123123123",
                    Height = 10,
                    Length = 10,
                    Width = 10,
                    Weight = -1
                }
            };
        }
    }
}
