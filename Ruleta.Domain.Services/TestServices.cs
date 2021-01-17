using Ruleta.Domain.BusinessLayer.Interfaces;
using Ruleta.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Services
{
    public class TestServices : ITestServices
    {
        private readonly ITestBL _testBL;

        public TestServices(ITestBL testBL)
        {
            _testBL = testBL;
        }

        public string GetMessage(string name)
        {
            return _testBL.GetMessage(name);
        }
    }
}
