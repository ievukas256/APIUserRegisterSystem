using System.ComponentModel.DataAnnotations.Schema;

namespace APIUserRegisterSystem.Entities
{
    public class User
    {
        public int Id { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        [ForeignKey("Login")]
        public int LoginId { get; set; }
        public Login Login { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int IdNumber { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }
        public string Photo { get; set; }
        
    }
}
