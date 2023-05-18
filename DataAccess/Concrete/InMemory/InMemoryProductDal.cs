using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            //Veri tabanından veri geliyormuşçasına simile(Yalandan) ediyoruz
            _products = new List<Product>() { new Product {ProductID=1,CategoryID=1,ProductName="Bardak",UnitPrice=15,UnitInStock=15 },
                                              new Product {ProductID=2,CategoryID=1,ProductName="Kamera",UnitPrice=500,UnitInStock=3 },
                                              new Product {ProductID=3,CategoryID=2,ProductName="Telefon",UnitPrice=1500,UnitInStock=2 },
                                              new Product {ProductID=4,CategoryID=2,ProductName="Klavye",UnitPrice=150,UnitInStock=65 },
                                              new Product {ProductID=5,CategoryID=2,ProductName="Mause",UnitPrice=85,UnitInStock=1 }
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            /*
            Product productDelete = null;
            foreach (var p in _products)
            {
                if (p.ProductID==product.ProductID)
                {
                    productDelete = p;
                }
            }
            */



            // foreach kullanmamk için aşağıdaki kodu kullanabilirsin
            //LİNQ kullanmak daha mantıklı
           Product productToDelete = _products.SingleOrDefault(p => p.ProductID==product.ProductID);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        //Verileri istediğim CateoryID ye göre listele
        public List<Product> GetAllByCategory(int categoryID)
        {
            return _products.Where(p => p.CategoryID == categoryID).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul demektir.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductID = product.ProductID;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }
    }
}

