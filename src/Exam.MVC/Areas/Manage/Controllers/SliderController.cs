using Exam.Business.Services.Interface;
using Exam.Core.Models;
using Exam.Data.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Exam.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly ISliderService _sliderService;

        public SliderController(AppDbContext context, IWebHostEnvironment env, ISliderService sliderService)
        {
            _context = context;
            _env = env;
            _sliderService = sliderService;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _sliderService.GetAllASync();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                await _sliderService.CreateAsync(slider);
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            Slider slider =await _sliderService.GetByIdASync(id);
            if(slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Slider slider)
        {
            if(!ModelState.IsValid) return View();
            await _sliderService.UpdateAsync(slider);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sliderService.DeleteAsync(id);
            }
            catch (NullReferenceException)
            {
                throw;
            }
            return Ok();
        }

    }
   
}
