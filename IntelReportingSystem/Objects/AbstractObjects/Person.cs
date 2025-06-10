using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelReportingSystem.Enums;

namespace IntelReportingSystem.Objects.AbstractObjects
{
    internal abstract class Person
    {
        protected string Name { get; set; }
        protected string SecretCode { get; set; }
        //protected string UserName { get; set; }
        protected PersonType PersonType { get; set; }
        protected int ID { get; set; }
    }
}
