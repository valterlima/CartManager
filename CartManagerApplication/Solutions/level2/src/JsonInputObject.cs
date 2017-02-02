﻿using System;
using System.Collections.Generic;

namespace CartManagerApplication.Solutions.level2.src
{
    public class JsonInputObject
    {
        public List<Article> articles { get; set; }
        public List<Cart> carts { get; set; }
        public List<DeliveryFee> delivery_fees { get; set; }

        public Article getArticleById(int id)
        {
            return this.articles.Find(x => x.id == id);
        }
    }
    public class Cart
    {
        public int id { get; set; }
        public List<CartItem> items { get; set; }
        public int delivery_fee { get; set; }
        public int sub_total { get; set; }

        public int getTotals()
        {
            return sub_total + delivery_fee;
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
}
