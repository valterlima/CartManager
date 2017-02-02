using Microsoft.VisualStudio.TestTools.UnitTesting;
using CartManagerApplication.Solutions.level2;
using CartManagerApplication.Solutions.level2.src;
using System.Collections.Generic;

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
            JsonOutputObject expectedJsonOutput = sol2.LoadExpectedOutput();
            

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
        [TestMethod]
        public void VerifyDeliveryFees()
        {
            Solution2 sol2 = new Solution2();

            List<Article> articles = new List<Article>();
            articles.Add(new Article(1, "Water", 100));
            articles.Add(new Article(2, "Cup", 200));

            List<Cart> carts = new List<Cart>();

            List<CartItem> items1 = new List<CartItem>();
            items1.Add(new CartItem(1, 3));
            items1.Add(new CartItem(2, 1));

            List<CartItem> items2 = new List<CartItem>();
            items2.Add(new CartItem(1, 4));
            items2.Add(new CartItem(2, 3));

            List<CartItem> items3 = new List<CartItem>();
            items3.Add(new CartItem(1, 0));
            items3.Add(new CartItem(2, 10));

            int cart1_id = 1;
            int cart2_id = 2;
            int cart3_id = 3;
            carts.Add(new Cart(cart1_id, items1));
            carts.Add(new Cart(cart2_id, items2));
            carts.Add(new Cart(cart3_id, items3));

            List<DeliveryFee> delivery_fees = new List<DeliveryFee>();
            int delivery_price1 = 1000;
            int delivery_price2 = 500;
            int delivery_price3 = 0;
            delivery_fees.Add(new DeliveryFee(new TransactionVolume(0, 1000), delivery_price1));
            delivery_fees.Add(new DeliveryFee(new TransactionVolume(1000, 2000), delivery_price2));
            delivery_fees.Add(new DeliveryFee(new TransactionVolume(2000, null), delivery_price3));

            sol2.input = new JsonInputObject(articles, carts, delivery_fees);
            sol2.run();
            
            JsonOutputObject result = sol2.output;

            Assert.AreEqual(result.carts.Find(x => x.id == cart1_id).total, 1500);
            Assert.AreEqual(result.carts.Find(x => x.id == cart2_id).total, 1500);
            Assert.AreEqual(result.carts.Find(x => x.id == cart3_id).total, 2000);

        }
    }
}
