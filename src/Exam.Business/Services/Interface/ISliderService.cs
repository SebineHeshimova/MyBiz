using Exam.Core.Models;
using Exam.Core.Repositories.Interface;
using Exam.Data.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Services.Interface
{
    public interface ISliderService
    {
        Task CreateAsync(Slider slider);
        Task DeleteAsync(int id);
        Task<List<Slider>> GetAllASync();
        Task<Slider> GetByIdASync(int id);
        Task UpdateAsync(Slider slider);
    }
}
