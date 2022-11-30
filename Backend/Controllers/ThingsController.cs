using AutoMapper;
using Backend.Data.UOW;
using Backend.Entities;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Backend.Controllers
{
    public class ThingsController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public ThingsController(
            IUnitOfWork uow,
            IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var things = uow.ThingRepository.GetAll();
            var thingsModel = mapper.Map<List<ThingViewModel>>(things);
            return View(thingsModel);
        }

        public IActionResult Create()
        {
            var thingModel = new ThingViewModel();
            thingModel.Categories = CategoriesList();
            return View(thingModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Create(ThingViewModel thingModel)
        {
            if (!ModelState.IsValid) 
            {
                ModelState.AddModelError(String.Empty, $"Especifique correctamente los campos");
                thingModel.Categories = CategoriesList();
                return View(thingModel);
            };
            
            var currentThings = uow.ThingRepository.GetAll();

            if(currentThings.Any(t => t.Description == thingModel.Description))
            {
                ModelState.AddModelError(String.Empty, $"Ya existe una cosa con esa descripcion. ");
                thingModel = new ThingViewModel { 
                    Categories = CategoriesList(),
                };
                return View(thingModel);
            }

            var thingEntity = mapper.Map<Thing>(thingModel);
            uow.ThingRepository.Add(thingEntity);
            await uow.CompleteAsync();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(int? id)
        {
            if(id is null) return NotFound();
            var thing = uow.ThingRepository.GetById(id.Value);
            if(thing is null) return NotFound();
            ThingViewModel thingModel = mapper.Map<ThingViewModel>(thing);
            thingModel.Categories = CategoriesList();
            return View(thingModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ThingViewModel thingModel)
        {
            if (id != thingModel.Id) return NotFound();
            if (ModelState.IsValid)
            {
                var thingEntity = mapper.Map<Thing>(thingModel);
                uow.ThingRepository.Update(thingEntity);
                await uow.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(new ThingViewModel { Categories = CategoriesList() });
        }

        public IActionResult Delete(int? id)
        {
            if (id is null) return NotFound();
            var thing = uow.ThingRepository.GetById(id.Value);
            if (thing is null) return NotFound();
            ThingViewModel thingModel = mapper.Map<ThingViewModel>(thing);
            return View(thingModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var thingToDelete = uow.ThingRepository.GetById(id);
            if (thingToDelete is null) return NotFound();
            uow.ThingRepository.Delete(thingToDelete);
            await uow.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
        private List<SelectListItem> CategoriesList()
        {
            return mapper.Map<List<SelectListItem>>(uow.CategoryRepository.GetAll());
        }
    }
}
