using Ruleta.Domain.BusinessLayer.Interfaces;
using Ruleta.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.BusinessLayer
{
    public class TestBL : ITestBL
    {
        public string GetMessage(string name)
        {
            TestConecction test = new TestConecction();
            return "Hello " + name;
        }
    }
}
