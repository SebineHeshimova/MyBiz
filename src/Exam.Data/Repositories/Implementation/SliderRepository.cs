using Exam.Core.Models;
using Exam.Core.Repositories.Interface;
using Exam.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Repositories.Implementation
{
    public class SliderRepository : GenericRepository<Slider>, ISliderRepository
    {
        public SliderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
