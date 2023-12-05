using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.CustomException
{
    internal class InvalidImageLength : Exception
    {
        public string PropertyName { get; set; }
        public InvalidImageLength()
        {
        }

        public InvalidImageLength(string propertyName,string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
