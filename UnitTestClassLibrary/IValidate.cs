using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestClassLibrary
{
    public interface IValidate
    {
        bool ValidateEmail(string email);
        bool SendEmail(string email, string msubject, string mbody);
    }
}
