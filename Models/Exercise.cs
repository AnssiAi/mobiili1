using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harjoitusi.Models
{
    public record Exercise(int Id, string Name, string Type, List<string> Tags, List<string> Targets)
    {

    }
}
