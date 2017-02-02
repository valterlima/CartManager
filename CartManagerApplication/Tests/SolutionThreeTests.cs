using CartManagerApplication.Solutions.level3;
using CartManagerApplication.Solutions.level3.src;
using NUnit.Framework;

namespace CartManagerApplication
{
    [TestFixture]
    public class SolutionThreeTests
    {
        // Testing if the generated output.json matches the expected output.json
        [Test]
        public void SolutionThree_CompareResultsWithExpected()
        {
            Solution3 sol3 = new Solution3();
            sol3.run();
            
            JsonOutputObject actualJsonOutput = sol3.output;
            JsonOutputObject expectedJsonOutput = sol3.LoadExpectedOutput();
            

            for(int i = 0; i < actualJsonOutput.carts.Count; i++)
            {
                Assert.AreEqual(actualJsonOutput.carts[i].id, expectedJsonOutput.carts[i].id);
                Assert.AreEqual(actualJsonOutput.carts[i].total, expectedJsonOutput.carts[i].total);
            }
            
        }

        // All cart ids from data.json must be in the resulting output.json, and no more than these
        [Test]
        public void SolutionThree_VerifyAllCartIds()
        {
            Solution3 sol3 = new Solution3();
            sol3.run();

            JsonInputObject input = sol3.input;
            JsonOutputObject result = sol3.output;

            foreach (Cart inputCart in input.carts)
            {
                Assert.IsTrue(result.carts.Exists(x => x.id == inputCart.id));
            }

            Assert.IsTrue(input.carts.Count == result.carts.Count);

            Assert.IsFalse(result.carts.Exists(x => x.id == 999));
        }
    }
}
