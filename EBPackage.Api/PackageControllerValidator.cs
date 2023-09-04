using EBPackage.Entities.DataContract.Requests;

namespace EBPackage.Api
{
    public static class PackageControllerValidator
    {
        public static void Validate(this PackageRequest packageRequest)
        {
            if (!ValidNumber(packageRequest.Weight))
            {
                throw new ArgumentException("Weight is not a valid number");
            }
            if (!ValidNumber(packageRequest.Length))
            {
                throw new ArgumentException("Length is not a valid number");
            }
            if (!ValidNumber(packageRequest.Height))
            {
                throw new ArgumentException("Height is not a valid number");
            }
            if (!ValidNumber(packageRequest.Width))
            {
                throw new ArgumentException("Width is not a valid number");
            }
        }

        private static bool ValidNumber(double number)
        {
            return number > 0;
        }
    }
}
