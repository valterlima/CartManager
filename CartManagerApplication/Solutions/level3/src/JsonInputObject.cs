﻿using System;
using System.Collections.Generic;

namespace CartManagerApplication.Solutions.level3.src
{
    public class JsonInputObject
    {
        public List<Article> articles { get; set; }
        public List<Cart> carts { get; set; }
        public List<DeliveryFee> delivery_fees { get; set; }
        public List<Discount> discounts { get; set; }

    }
    public class Cart
    {
        public int id { get; set; }
        public List<CartItem> items { get; set; }
        public int delivery_fee { get; set; }
        public int sub_total { get; set; }
        public List<Article> articles { get; set; }
        public List<DeliveryFee> delivery_fees { get; set; }
        public List<Discount> discounts { get; set; }

        public Article getArticleById(int id)
        {
            return this.articles.Find(x => x.id == id);
        }
        public int getItemTotals()
        {
            int total = 0;
            foreach (CartItem item in this.items)
            {
                int item_price = this.articles.Find(x => x.id == item.article_id).price;
                Discount d = this.discounts.Find(x => x.article_id == item.article_id);
                if (d != null)
                {
                    item_price = d.getDiscountedPrice(item_price);
                }
                total += item_price * item.quantity;
            }
            return total;
        }

        public int getTotals()
        {
            return sub_total + delivery_fee;
        }

        public int getDeliveryFee(int total)
        {
            int delivery_fee = 0;
            foreach (DeliveryFee fee in delivery_fees)
            {
                if (total >= fee.eligible_transaction_volume.min_price
                    && (total < fee.eligible_transaction_volume.max_price || fee.eligible_transaction_volume.max_price == null))
                {
                    delivery_fee = fee.price;
                }
            }
            return delivery_fee;
        }
    }
    public class CartItem
    {
        public int article_id { get; set; }
        public int quantity { get; set; }
        
}
    public class Article
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
    }
    public class DeliveryFee
    {
        public TransactionVolume eligible_transaction_volume { get; set; }
        public int price { get; set; }
    }
    public class TransactionVolume
    {
        public int? min_price { get; set; }
        public int? max_price { get; set; }
    }
    public class Discount
    {
        public int article_id { get; set; }
        public string type { get; set; }
        public int value { get; set; }

        public int getDiscountedPrice(int price)
        {
            if (string.Equals("amount", this.type))
            {
                return price - this.value;
            }
            if (string.Equals("percentage", this.type))
            {
                return price * (100 - value) / 100;
            }
            else
            {
                return price;
            }
        }
    }
}
