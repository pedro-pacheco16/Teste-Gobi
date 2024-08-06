using Gobi.Test.Jr.Application;
using Gobi.Test.Jr.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Gobi.Tests.Jr.WebApp.Controllers
{
	public class TodoController : Controller
	{
		private readonly TodoItemService _todoItemService;

		public TodoController(TodoItemService todoItemService)
		{
			_todoItemService = todoItemService;
		}

		public async Task<IActionResult> Index()
		{
			var items = await _todoItemService.GetAll();

			return View(items);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(TodoItemDTO todoItem)
		{
		
				await _todoItemService.CreateItem(todoItem);
				return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> UpdateItem(int id)
		{

			var item = await _todoItemService.GetById(id);

			var itemDto = new TodoItemDTO
			{
				Description = item.Description,
				Completed = item.Completed
			};

			return View(itemDto);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateItem(TodoItemDTO todoItem, int id)
		{

			await _todoItemService.UpdateItem(todoItem,id);
			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			await _todoItemService.DeleteItem(id);
			return RedirectToAction(nameof(Index));
		} 
	}
}