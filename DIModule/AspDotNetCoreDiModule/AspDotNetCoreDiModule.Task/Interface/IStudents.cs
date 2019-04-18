using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreDiModule.Task.Interface
{
   public interface IStudents
    {
      int Id { get; set; }

      string Name { get; set; }

      int Age { get; set; }
    }
}
