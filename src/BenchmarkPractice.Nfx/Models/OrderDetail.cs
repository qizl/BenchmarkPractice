using Com.EnjoyCodes.SqlAttribute;

namespace BenchmarkPractice.Nfx.Models
{
    [Table(Name = "T_OrderDetail")]
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OutPaperCode { get; set; }
        public string InName { get; set; }
        public string InUserNo { get; set; }
    }
}
