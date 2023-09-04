namespace EBPackage.Entities.DataContract.Models
{
    public class Package
    {
        public string KolliId { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public bool IsValid
        {
            get
            {
                return Weight <= 2000 && Length <= 60 && Height <= 60 && Width <= 60;
            }
        }
    }
}
