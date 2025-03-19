using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoenixLifeApi.Databases;
using PhoenixLifeApi.Models;
using System.Diagnostics;
using System;

namespace PhoenixLifeApi.Controllers
{
	public class ProjectController : ControllerBase
	{
		private readonly PhoenixContext _phoenixContext;

		public ProjectController(PhoenixContext context)
		{
			_phoenixContext = context;
		}

		[HttpGet]
		[Route("/Projects")]
		public async Task<ActionResult> GetProject()

		{
			var Projects = await _phoenixContext.Projects.Select(x => x).ToListAsync();
			if(Projects == null)
			{
				return NotFound();
			}
			return Ok(Projects);
		}

		[HttpGet]
		[Route("/Projects/{ProjectId}")]
		public async Task<ActionResult> GetProjectById(int ProjectId)
		{
			var Project = _phoenixContext.Projects.FirstOrDefault(x => x.Id == ProjectId);
			if(Project != null)
			{
                return Ok(Project);
			}
			return NotFound();
		}

		[HttpPost]
		[Route("/Projects/Create")]
		public async Task<ActionResult> AddProject([FromBody] Project project)
		{
			project.CreationTimestamp = DateTime.Now.ToString("MM-dd-yyyy");
			await _phoenixContext.Projects.AddAsync(project);
			await _phoenixContext.SaveChangesAsync();
			return Ok();
		}

		[HttpPost]
		[Route("/Projects/Edit")]
		public async Task<ActionResult> EditProject([FromBody] Project project)
		{
			//_phoenixContext.Projects.Attach(project);
			//_phoenixContext.Entry(project).Property(x => x.Id).IsModified = true;
			//await _phoenixContext.SaveChangesAsync();
			return Ok();
		}

		[Route("/Projects/Delete/{ProjectId}")]
		public async Task<ActionResult> DeleteProject(int ProjectId)
		{
			var p = _phoenixContext.Projects.FirstOrDefault(x => x.Id == ProjectId);
			if (p != null)
			{
				_phoenixContext.Projects.Remove(p);
				List<ProjectTask> ProjectTasks = await _phoenixContext.ProjectTasks.Where(x => x.ProjectId == ProjectId).ToListAsync();

				if(ProjectTasks != null)
				{
					_phoenixContext.ProjectTasks.RemoveRange(ProjectTasks);
				}
				await _phoenixContext.SaveChangesAsync();
				Debug.WriteLine("Project Deleted");
				return Ok();
			}
			return BadRequest();
		}

		[HttpGet]
		[Route("/Projects/Categories/{id}")]
		public async Task<ActionResult> GetProjectByCategory(int id)
		{
			var Projects = await _phoenixContext.Projects.Where(x => x.Category == id).ToListAsync();
			if (Projects == null)
			{
				return NotFound();
			}
			return Ok(Projects);
		}

		[HttpGet]
		[Route("/Projects/Search/Query={Query}&Category={CategoryId}")]
		public async Task<ActionResult> SearchProject(string Query, int CategoryId )
		{
			var Projects = await _phoenixContext.Projects.Where(x => x.Name.Contains(Query) && x.Category==CategoryId).ToListAsync();
			if(Projects==null)
			{
				return NotFound();
			}
			return Ok(Projects);
		}

		[HttpGet]
		[Route("/Projects/Tasks/{ProjectId}")]
		public async Task<ActionResult> GetProjectTasks(int ProjectId)
		{
			var Todos = await _phoenixContext.ProjectTasks.Where(x => x.ProjectId == ProjectId).ToListAsync();
			if (Todos == null) {
				return NotFound();
			}
			return Ok(Todos);
		}


		//Project Task CRUD
		[HttpPost]
		[Route("/Projects/Tasks/Create")]
		public async Task<ActionResult> CreateTask([FromBody] ProjectTask projectTask)
		{
            projectTask.Status = 0;
            projectTask.DateCreated = DateTime.Now.ToString("MM-dd-yyyy");
			await _phoenixContext.ProjectTasks.AddAsync(projectTask);
			await _phoenixContext.SaveChangesAsync();
			return Ok();
		}

		[HttpPost]
		[Route("/Projects/Tasks/Edit")]
		public async Task<ActionResult> EditTask([FromBody] ProjectTask projectTask)
		{
			_phoenixContext.ProjectTasks.Update(projectTask);
			await _phoenixContext.SaveChangesAsync();
			return Ok();
		}

		[HttpPost]
		[Route("/Projects/Tasks/Update={TaskId}&Status={Status}")]
		public async Task<ActionResult> TaskUpdateStatus(int TaskId, int Status)
		{
			var pTask = _phoenixContext.ProjectTasks.FirstOrDefault(x => x.Id == TaskId);
			int NewStatus = -1;
			if (pTask != null)
			{
				if(Status == 0)
				{
					NewStatus = 1;
				}else if(Status == 1)
				{
					NewStatus = 2;
					pTask.DateCompleted = DateTime.Now.ToString("MM-dd-yyyy");
				}else
				{
					NewStatus = 2;
				}
				pTask.Status = NewStatus;
				_phoenixContext.ProjectTasks.Update(pTask);
				await _phoenixContext.SaveChangesAsync();
			}
			return Ok();
        }

		[HttpPost]
		[Route("/Projects/Tasks/Delete/{ProjectTaskId}")]
		public async Task<ActionResult> DeleteProjectTask(int ProjectTaskId)
		{
			var p = _phoenixContext.ProjectTasks.FirstOrDefault(x => x.Id == ProjectTaskId);
			if (p != null)
			{
				_phoenixContext.ProjectTasks.Remove(p);
				await _phoenixContext.SaveChangesAsync();
				return Ok();
			}
			return BadRequest();
		}

	}
}
