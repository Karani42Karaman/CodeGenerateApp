

namespace CodeGenerateApp.Model
{
    public class Receipt
    {
        public string locale { get; set; }
        public string description { get; set; }
        public BoundingPoly boundingPoly { get; set; }
    }
}
