using App.Domain.Core.Contracts;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace App.Endpoint.Mvc.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGenericRepository<Product> _genericRepository;

        public ProductController(IGenericRepository<Product> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _genericRepository.GetAll();
            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                
               await _genericRepository.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _genericRepository.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
               await _genericRepository.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        

        
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _genericRepository.Get(id);
            if (product != null)
            {
              await _genericRepository.Delete(product);
            }
            return RedirectToAction("Index");
        }
    }
}
