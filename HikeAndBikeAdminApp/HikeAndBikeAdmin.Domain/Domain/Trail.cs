using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HikeAndBikeAdmin.Domain.Domain
{
    public class Trail : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Difficulty { get; set; }
        [Required]
        public Double Price { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Double Length { get; set; }
        public string Guide { get; set; }
    }
}
