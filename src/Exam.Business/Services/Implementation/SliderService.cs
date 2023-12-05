using Exam.Business.CustomException;
using Exam.Business.Services.Interface;
using Exam.Core.Models;
using Exam.Core.Repositories.Interface;
using Exam.Data.DAL;
using Exam.Data.Repositories.Implementation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Services.Implementation
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IWebHostEnvironment _env;

        public SliderService(ISliderRepository sliderRepository, IWebHostEnvironment env)
        {
            _sliderRepository = sliderRepository;
            _env = env;
        }
        public async Task CreateAsync(Slider slider)
        {
            if (slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg")
            {
                throw new InvalidContentType("ImageFile", "jyhrthyrt");
            }
            if (slider.ImageFile.Length > 2097152)
            {
                throw new InvalidImageLength("ImageFile", "sjgfbeh");
            }
            string fileName = slider.ImageFile.FileName;
            if (fileName.Length > 64)
            {
                fileName = fileName.Substring(fileName.Length - 64, 64);
            }
            fileName = Guid.NewGuid().ToString();
            string path = Path.Combine(_env.WebRootPath, "uploads/sliders", fileName);
            using (FileStream fileStreem = new FileStream(path, FileMode.Create))
            {
                slider.ImageFile.CopyTo(fileStreem);
            }

            slider.ImageUrl = fileName;
            await _sliderRepository.CreateAsync(slider);
            await _sliderRepository.CommitAsync();
        }
        public async Task UpdateAsync(Slider slider)
        {
            Slider existSlider =await _sliderRepository.GetByIdAsync(slider.Id);
            if (slider == null)
            {
                throw new NullReferenceException();
            }
            if (slider.ImageFile != null)
            {
                if (slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg")
                {
                    throw new InvalidContentType("ImageFile", "jyhrthyrt");
                }
                if (slider.ImageFile.Length > 2097152)
                {
                    throw new InvalidImageLength("ImageFile", "sjgfbeh");
                }

                if (existSlider.ImageUrl != null)
                {
                    string deletePath = Path.Combine(_env.WebRootPath, "uploads/sliders", existSlider.ImageUrl);

                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                }


                string fileName = slider.ImageFile.FileName;
                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }
                fileName = Guid.NewGuid().ToString();
                string path = Path.Combine(_env.WebRootPath, "uploads/sliders", fileName);
                using (FileStream fileStreem = new FileStream(path, FileMode.Create))
                {
                    slider.ImageFile.CopyTo(fileStreem);
                }

                existSlider.ImageUrl=slider.ImageUrl;   
            }
            existSlider.Title = slider.Title;
            existSlider.Description=slider.Description;
            _sliderRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Slider slider =await _sliderRepository.GetByIdAsync(id);
            if(slider == null)
            {
                throw new NullReferenceException();
            }
            _sliderRepository.Delete(slider);
            _sliderRepository.CommitAsync();
        }

        public Task<List<Slider>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Slider>> GetAllASync()
        {
            throw new NotImplementedException();
        }

        public Task<Slider> GetByIdASync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
