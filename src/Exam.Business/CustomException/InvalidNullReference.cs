using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.CustomException
{
    internal class InvalidNullReference : Exception
    {
        public string PropertyName { get; set; }
        public InvalidNullReference()
        {
        }

        public InvalidNullReference(string propertyName,string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
