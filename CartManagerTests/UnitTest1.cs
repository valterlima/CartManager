using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CartManagerApplication.Solutions;
using CartManagerApplication.Solutions.level1;
using CartManagerApplication.Solutions.level1.src;

namespace CartManagerTests
{
    [TestClass]
    public class UnitTest1
    {
        // Testing if the generated output.json matches the expected output.json
        [TestMethod]
        public void TestSolution1()
        {
            Solution1 sol1 = new Solution1();
            sol1.run();
            sol1.save();

            JsonOutputObject actualJsonOutput = new JSONManager().LoadActualOutput("level1");
            JsonOutputObject expectedJsonOutput = new JSONManager().LoadExpectedOutput("level1");
            

            for(int i = 0; i < actualJsonOutput.carts.Count; i++)
            {
                Assert.AreEqual(actualJsonOutput.carts[i].id, expectedJsonOutput.carts[i].id);
                Assert.AreEqual(actualJsonOutput.carts[i].total, expectedJsonOutput.carts[i].total);
            }
            
        }
    }
}
