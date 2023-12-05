using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.CustomException
{
    internal class InvalidContentType : Exception
    {
        public string PropertyName { get; set; }
        public InvalidContentType()
        {
        }

        public InvalidContentType(string propertyName,string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
