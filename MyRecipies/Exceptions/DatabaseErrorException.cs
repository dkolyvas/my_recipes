using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Exceptions
{
    internal class DatabaseErrorException : Exception
    {
        public DatabaseErrorException() : base("Database error. Unable to save changes") 
        {
        }
    }
}
