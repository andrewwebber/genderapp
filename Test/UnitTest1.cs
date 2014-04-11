using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using GenderApp.Aggregates;
using System.Diagnostics;

namespace Test
{
    [TestClass]
    public class GenderAggregatesTestClass
    {
        [TestMethod]
        public void GenderRetriever()
        {
            var genderRetriever = new GenderRetriever(new PositiveNegativeIntegerBasedGenderFormatter());
            for (int i = 0; i < 100; i++)
            {
                var result = genderRetriever.GetContactsAsync(new GenderRequest[] { new GenderRequest() { FirstName = "Andrew", LastName = "Webber" } }).Result;
                foreach (var item in result)
                {
                    Debug.WriteLine(item.Gender);
                }            
            }            
        }
    }
}
