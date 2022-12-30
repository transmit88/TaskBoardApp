using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.TaskConst;

namespace TaskBoardApp.Models.Task
{
    public class TaskFormModel
    {

        [Required]
        [StringLength(MaxTaskTitle, MinimumLength = MinTaskTitle,
            ErrorMessage = "Title should be a least {2} chatacters long.")]
        public string Title { get; set; }

        [Required]
        [StringLength(MaxTaskDescription, MinimumLength = MinTaskDescription,
            ErrorMessage = "Description should be a least {2} chatacters long.")]
        public string Description { get; set; }

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; }
    }
}
