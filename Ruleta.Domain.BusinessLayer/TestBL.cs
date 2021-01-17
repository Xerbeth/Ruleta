using Ruleta.Domain.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.BusinessLayer
{
    public class TestBL : ITestBL
    {
        public string GetMessage(string name)
        {
            return "Hello " + name;
        }
    }
}
