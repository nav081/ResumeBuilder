using System;
using System.ComponentModel.DataAnnotations;

namespace ResumeBuilder.Data.Models.Common
{
    public abstract class BaseEntitites
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
