using CartManagerApplication.src.level3;
using NUnit.Framework;
using System.Collections.Generic;

namespace CartManagerApplication
{
    [TestFixture]
    public class SolutionThreeTests
    {
        [SetUp]
        protected void SetUp()
        {
        }

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
        
        // Test for the correct delivery fees and Discounts
        [Test]
        public void SolutionThree_VerifyDeliveryFeesAndDiscounts()
        {
            Solution3 sol3 = new Solution3();

            List<Article> articles = new List<Article>();
            articles.Add(new Article(1, "Water", 100)); //80
            articles.Add(new Article(2, "Cup", 200)); //180

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

            List<CartItem> items4 = new List<CartItem>();
            items4.Add(new CartItem(1, 0));

            int cart1_id = 1;
            int cart2_id = 2;
            int cart3_id = 3;
            int cart4_id = 4;
            carts.Add(new Cart(cart1_id, items1));
            carts.Add(new Cart(cart2_id, items2));
            carts.Add(new Cart(cart3_id, items3));
            carts.Add(new Cart(cart4_id, items4));

            List<DeliveryFee> delivery_fees = new List<DeliveryFee>();
            int delivery_price1 = 1000;
            int delivery_price2 = 500;
            int delivery_price3 = 0;
            delivery_fees.Add(new DeliveryFee(new TransactionVolume(0, 1000), delivery_price1));
            delivery_fees.Add(new DeliveryFee(new TransactionVolume(1000, 2000), delivery_price2));
            delivery_fees.Add(new DeliveryFee(new TransactionVolume(2000, null), delivery_price3));

            List<Discount> discounts = new List<Discount>();
            discounts.Add(new Discount(1, "amount", 20));
            discounts.Add(new Discount(2, "percentage", 10));

            sol3.input = new JsonInputObject(articles, carts, delivery_fees, discounts);
            sol3.run();
            
            int cart1_sub_total_expected = 420;
            int cart2_sub_total_expected = 860;
            int cart3_sub_total_expected = 1800;
            int cart4_sub_total_expected = 0;

            Assert.AreEqual(sol3.input.carts.Find(x => x.id == cart1_id).sub_total, cart1_sub_total_expected);
            Assert.AreEqual(sol3.input.carts.Find(x => x.id == cart2_id).sub_total, cart2_sub_total_expected);
            Assert.AreEqual(sol3.input.carts.Find(x => x.id == cart3_id).sub_total, cart3_sub_total_expected);
            Assert.AreEqual(sol3.input.carts.Find(x => x.id == cart4_id).sub_total, cart4_sub_total_expected);


            JsonOutputObject result = sol3.output;

            int cart1_total_expected = 1420;
            int cart2_total_expected = 1860;
            int cart3_total_expected = 2300;
            int cart4_total_expected = 1000;

            Assert.AreEqual(result.carts.Find(x => x.id == cart1_id).total, cart1_total_expected);
            Assert.AreEqual(result.carts.Find(x => x.id == cart2_id).total, cart2_total_expected);
            Assert.AreEqual(result.carts.Find(x => x.id == cart3_id).total, cart3_total_expected);
            Assert.AreEqual(result.carts.Find(x => x.id == cart4_id).total, cart4_total_expected);

        }
    }
}
