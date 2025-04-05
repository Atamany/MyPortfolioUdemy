using System.ComponentModel.DataAnnotations;

namespace MyPortfolioUdemy.DAL.Entities
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public string AccountPassword { get; set; }
        public string AccountImageUrl { get; set; }
    }
}
