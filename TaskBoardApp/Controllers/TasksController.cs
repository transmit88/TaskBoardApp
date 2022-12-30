using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskBoardAppDbContext context;

        public TasksController(TaskBoardAppDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            TaskFormModel taskModel = new TaskFormModel()
            {
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public IActionResult Create(TaskFormModel model)
        {
            if(!GetBoards().Any(b => b.Id == model.BoardId))
            {
                this.ModelState.AddModelError(nameof(model.BoardId), "Board does not exist.");
            }

            string currentUserId = GetUserId();
            TaskBoardApp.Data.Entities.Task task = new()
            {
                Title = model.Title,
                Description= model.Description,
                CreatedOn = DateTime.Now,
                BoardId = model.BoardId,
                OwnerId = currentUserId,
            };

            context.Tasks.Add(task);
            context.SaveChanges();

            return RedirectToAction("All", "Boards");
        }

        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);

        private IEnumerable<TaskBoardModel> GetBoards()
        {
            return context.Boards.Select(b => new TaskBoardModel
            {
                Id = b.Id,
                Name = b.Name,
            });
        }

        public IActionResult Details(int id)
        {
            var task = context.Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                })
                .FirstOrDefault();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        //Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
           var task = context.Tasks.Find(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            var model = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, TaskFormModel model)
        {
            var task = context.Tasks.Find(id);
            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            if (!GetBoards().Any(b => b.Id == model.BoardId))
            {
                this.ModelState.AddModelError(nameof(model.BoardId), "Boarddoes not exist.");
            }

            task.Title = model.Title;
            task.Description = model.Description;
            task.BoardId = model.BoardId;

            context.SaveChanges();
            return RedirectToAction("All", "Boards");
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = context.Tasks.Find(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            var model = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(TaskViewModel model)
        {
            var task = context.Tasks.Find(model.Id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            context.Tasks.Remove(task); // Remove from Database 
            context.SaveChanges();

            return RedirectToAction("All", "Boards");
        }
    }
}
