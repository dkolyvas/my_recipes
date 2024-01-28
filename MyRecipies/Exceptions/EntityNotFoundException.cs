using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Exceptions
{
    internal class EntityNotFoundException: Exception
    {
        public EntityNotFoundException(string entityName)
        :base($"The requested {entityName} was not found")
        { }

    }
}
