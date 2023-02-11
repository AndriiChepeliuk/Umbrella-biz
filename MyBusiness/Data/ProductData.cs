﻿using MyBusiness.Models.Product;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace MyBusiness.Data
{
    public class ProductData
    {
        public static void AddProduct(ProductModel product)
        {
            using (var context = new ApplicationContext())
            {
                var productToDB = new ProductModel();
                context.Products.Add(productToDB);
                context.SaveChanges();
            }
        }

        public static List<ProductModel> GetAllProducts()
        {
            using (var context = new ApplicationContext())
            {
                var products = context.Products.OrderBy(p => p.Category).ToList();

                foreach (var product in products)
                {
                    MemoryStream memoryStream = new MemoryStream(product.ProductImage);
                    product.Image = new BitmapImage();
                    product.Image.BeginInit();
                    product.Image.StreamSource = memoryStream;
                    product.Image.EndInit();
                }

                return products;
            }
        }

        public static ProductModel GetProductById(int id)
        {
            using (var context = new ApplicationContext())
            {
                var product = context.Products.FirstOrDefault(x => x.Id == id);
                return product;
            }
        }
    }
}