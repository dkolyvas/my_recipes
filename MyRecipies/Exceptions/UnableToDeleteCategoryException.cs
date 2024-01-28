using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Exceptions
{
    internal class UnableToDeleteCategoryException : Exception
    {
        public UnableToDeleteCategoryException() 
            : base("Η κατηγορία δεν μπορεί να διαγραφεί γιατί υπάρχουν συνδεδεμένες συνταγές με αυτήν")
        { }
    }
}
