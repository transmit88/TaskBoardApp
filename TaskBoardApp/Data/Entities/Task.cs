using Microsoft.AspNetCore.Http.Connections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp.Data.DataConstants.TaskConst;

namespace TaskBoardApp.Data.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxTaskTitle)]
        public string Title { get; set; }

        [Required]
        [MaxLength(MaxTaskDescription)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }
        [ForeignKey(nameof(BoardId))]
        public Board Board { get; init; }

        [Required]
        public string OwnerId { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public User Owner { get; init; }
    }
}
