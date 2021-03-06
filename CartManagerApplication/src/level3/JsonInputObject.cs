﻿using System;
using System.Collections.Generic;

namespace CartManagerApplication.src.level3
{
    public class JsonInputObject
    {
        public List<Article> articles { get; set; }
        public List<Cart> carts { get; set; }
        public List<DeliveryFee> delivery_fees { get; set; }
        public List<Discount> discounts { get; set; }

        public JsonInputObject(List<Article> articles, List<Cart> carts, List<DeliveryFee> delivery_fees, List<Discount> discounts)
        {
            this.articles = articles;
            this.carts = carts;
            this.delivery_fees = delivery_fees;
            this.discounts = discounts;
        }
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

        public Cart(int id, List<CartItem> items)
        {
            this.id = id;
            this.items = items;
        }

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

        public CartItem(int article_id, int quantity)
        {
            this.article_id = article_id;
            this.quantity = quantity;
        }
    }
    public class Article
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }

        public Article(int id, string name, int price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
    }
    public class DeliveryFee
    {
        public TransactionVolume eligible_transaction_volume { get; set; }
        public int price { get; set; }

        public DeliveryFee(TransactionVolume volume, int price)
        {
            this.eligible_transaction_volume = volume;
            this.price = price;
        }
    }
    public class TransactionVolume
    {
        public int? min_price { get; set; }
        public int? max_price { get; set; }

        public TransactionVolume(int? min_price, int? max_price)
        {
            this.min_price = min_price;
            this.max_price = max_price;
        }
    }
    public class Discount
    {
        public int article_id { get; set; }
        public string type { get; set; }
        public int value { get; set; }

        public Discount(int article_id, string type, int value)
        {
            this.article_id = article_id;
            this.type = type;
            this.value = value;
        }

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
