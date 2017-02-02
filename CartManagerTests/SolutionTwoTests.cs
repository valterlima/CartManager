using Microsoft.VisualStudio.TestTools.UnitTesting;
using CartManagerApplication.Solutions.level2;
using CartManagerApplication.Solutions.level2.src;

namespace CartManagerTests
{
    [TestClass]
    public class SolutionTwoTests
    {
        // Testing if the generated output.json matches the expected output.json
        [TestMethod]
        public void CompareResultsWithExpected()
        {
            Solution2 sol2 = new Solution2();
            sol2.run();
            
            JsonOutputObject actualJsonOutput = sol2.output;
            JsonOutputObject expectedJsonOutput = sol2.manager.LoadExpectedOutput();
            

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
            Solution2 sol2 = new Solution2();
            sol2.run();

            JsonInputObject input = sol2.input;
            JsonOutputObject result = sol2.output;

            foreach (Cart inputCart in input.carts)
            {
                Assert.IsTrue(result.carts.Exists(x => x.id == inputCart.id));
            }

            Assert.IsTrue(input.carts.Count == result.carts.Count);

            Assert.IsFalse(result.carts.Exists(x => x.id == 999));
        }

        // Test for the correct delivery fees
        /*[TestMethod]
        public void VerifyDeliveryFees()
        {
            Solution2 sol2 = new Solution2();
            sol2.run();

            JsonInputObject input = sol2.input;
            JsonOutputObject result = sol2.output;

            foreach (Cart inputCart in input.carts)
            {
                foreach(DeliveryFee del in input.delivery_fees)
                {
                    int sub_total = inputCart.sub_total
                    if (sub_total 
                }
                
            }
        }*/
    }
}
