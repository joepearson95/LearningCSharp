using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningCSharp.Models
{
    public class Blog
    {
        [Key]
        public int PostID { get; set; }

        [Required]
        [StringLength(100)]
        public string PostTitle { get; set; }

        [Required]
        [StringLength(255)]
        public string PostBody { get; set; }

        public string Author { get; set; }
        
        [Column(TypeName="datetime2")]
        public DateTime CreatedOn { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EditedOn { get; set; }
    }
}