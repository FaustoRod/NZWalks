using System.ComponentModel.DataAnnotations;

namespace NZWalksApi.Models.Dtos
{
    public class AddRegionRequest
    {
        //[Required]
        public string Code { get; set; }
        //[Required]
        public string Name { get; set; }
        //[Range(1,1000)]
        public double Area { get; set; }
        //[Range(1, 1000)]
        public double Lat { get; set; }
        //[Range(1, 1000)]
        public double Long { get; set; }
        //[Range(0, 1000)]
        public long Population { get; set; }
    }
}
