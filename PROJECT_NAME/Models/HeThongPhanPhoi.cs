using System.ComponentModel.DataAnnotations;

namespace PROJECT_NAME.Models
{
    public class HeThongPhanPhoi
    {
        [Key] 
        public required string MaHTPP { get; set; }
        public required string TenHTTP { get; set; }
    }
}