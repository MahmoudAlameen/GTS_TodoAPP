using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Shared;

namespace TodoApp.Application.DTOs
{
    public class TodoDTO
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "title of todo is required field")]
        [MaxLength(100, ErrorMessage = "title maximum length is 100 character")]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public Status? Status { get; set; }
        [Required]
        public Priority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
