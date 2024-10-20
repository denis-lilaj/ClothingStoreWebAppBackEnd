using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class OperationResult<T>
    {
        public T PayLoad { get; set; }
        public bool isError { get; set; }
        public List<Error> Errors { get; set; } = new List<Error>(); 

    }
}
 