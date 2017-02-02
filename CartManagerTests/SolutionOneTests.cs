using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CartManagerApplication.Solutions;
using CartManagerApplication.Solutions.level1;
using CartManagerApplication.Solutions.level1.src;

namespace CartManagerTests
{
    [TestClass]
    public class SolutionOneTests
    {
        // Testing if the generated output.json matches the expected output.json
        [TestMethod]
        public void CompareResultsWithExpected()
        {
            Solution1 sol1 = new Solution1();
            sol1.run();
            
            JsonOutputObject actualJsonOutput = sol1.output;
            JsonOutputObject expectedJsonOutput = sol1.LoadExpectedOutput();
            

            for(int i = 0; i < actualJsonOutput.carts.Count; i++)
            {
                Assert.AreEqual(actualJsonOutput.carts[i].id, expectedJsonOutput.carts[i].id);
                Assert.AreEqual(actualJsonOutput.carts[i].total, expectedJsonOutput.carts[i].total);
            }
            
        }

        // All cart ids from data.json must be in the resulting output.json, and no more than these
        [TestMethod]
        public void VerifyAllCartIds()
        {
            Solution1 sol1 = new Solution1();
            sol1.run();

            JsonInputObject input = sol1.input;
            JsonOutputObject result = sol1.output;

            foreach (Cart inputCart in input.carts)
            {
                Assert.IsTrue(result.carts.Exists(x => x.id == inputCart.id));
            }

            Assert.IsFalse(result.carts.Exists(x => x.id == 999));
        }
    }
}
