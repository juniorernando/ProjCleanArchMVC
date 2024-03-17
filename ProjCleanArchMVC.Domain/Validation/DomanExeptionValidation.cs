using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCleanArchMVC.Domain.Validation
{
    public class DomanExeptionValidation : Exception
    {
        public DomanExeptionValidation(string error) : base(error)
        {
        }
        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomanExeptionValidation(error);
        }

    }
}
