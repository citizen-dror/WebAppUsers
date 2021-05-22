using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebAppUsers.ModelsDto
{
    public class UserAddDto
    {
        public long UserId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }
        [StringLength(200)]
        public string WebSite { get; set; }
        [StringLength(200)]
        public string TimeZone { get; set; }
        [StringLength(200)]
        public string PhoneSkype { get; set; }
        [StringLength(1000)]
        public string About { get; set; }
        public byte[] Avatar { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public bool? SendTasks { get; set; }
        public int? TaskInterval { get; set; }
    }

    public class UserShortDto
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TimeZone { get; set; }
        public bool? SendTasks { get; set; }
        public int TaskInterval { get; set; }
    }
}
