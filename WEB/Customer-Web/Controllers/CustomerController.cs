using Customer_Web.Models;
using Customer_Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerApiService service;

        public CustomerController(ICustomerApiService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var result = await service.GetAll();

            return View(result.Content);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CustomerQuery query)
        {
            var result = await service.GetBySearch(query);

            return View(result.Content);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await service.GetById(id);

            return View(result.Content);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await service.Post(model);

            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await service.GetById(id);

            return View(result.Content);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Customer model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await service.Put(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await service.GetById(id);

            return View(result.Content);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, Customer model)
        {
            await service.Remove(model.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
