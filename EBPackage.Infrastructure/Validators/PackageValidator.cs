using EBPackage.Entities.DataContract.Requests;
using EBPackage.Entities.Exceptions;
using System.Text.RegularExpressions;

namespace EBPackage.Infrastructure.Validators
{
    public static class PackageValidator
    {
        public static void Validate(this PackageRequest packageRequest)
        {
            Validate(packageRequest.KolliId);

            if (!ValidNumber(packageRequest.Weight))
            {
                throw new WongInputException("Weight is not a valid number");
            }
            if (!ValidNumber(packageRequest.Length))
            {
                throw new WongInputException("Length is not a valid number");
            }
            if (!ValidNumber(packageRequest.Height))
            {
                throw new WongInputException("Height is not a valid number");
            }
            if (!ValidNumber(packageRequest.Width))
            {
                throw new WongInputException("Width is not a valid number");
            }
        }

        public static void Validate(this string kolliId)
        {
            if (string.IsNullOrEmpty(kolliId))
            {
                throw new WongInputException("KolliId can not be empty");
            }
            kolliId = kolliId.Trim();

            var isOnlyNumbers = Regex.IsMatch(kolliId, "^[0-9]+$");
            if (!isOnlyNumbers)
            {
                throw new WongInputException("KolliId must contain only digits");
            }
            if (kolliId.Length != 18)
            {
                throw new WongInputException("KolliId must contain 18 digits");
            }
            if (kolliId.Substring(0, 3) != "999")
            {
                throw new WongInputException("KolliId must start with 999");
            }
        }

        private static bool ValidNumber(double number)
        {
            return number > 0;
        }
    }
}
