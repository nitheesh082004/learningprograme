using System;

namespace ECommerceSearch
{
    // Step 2: Product Class Setup
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Product(int id, string name, string category)
        {
            ProductId = id;
            ProductName = name;
            Category = category;
        }

        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
        }
    }

    class Program
    {
        // Step 3.1: Linear Search by ProductId
        static Product LinearSearch(Product[] products, int id)
        {
            foreach (var product in products)
            {
                if (product.ProductId == id)
                    return product;
            }
            return null;
        }

        // Step 3.2: Binary Search by ProductId (Assumes array is sorted by ProductId)
        static Product BinarySearch(Product[] products, int id)
        {
            int left = 0;
            int right = products.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (products[mid].ProductId == id)
                    return products[mid];
                else if (products[mid].ProductId < id)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return null;
        }

        static void Main(string[] args)
        {
            // Step 2: Sample product data
            Product[] products = new Product[]
            {
                new Product(102, "Laptop", "Electronics"),
                new Product(205, "Shoes", "Apparel"),
                new Product(309, "Book", "Education"),
                new Product(401, "Headphones", "Electronics"),
                new Product(123, "Pen", "Stationery")
            };

            // Sort products for binary search
            Array.Sort(products, (a, b) => a.ProductId.CompareTo(b.ProductId));

            int searchId = 309;

            // Step 3: Linear Search
            Console.WriteLine("Linear Search:");
            var result1 = LinearSearch(products, searchId);
            Console.WriteLine(result1 != null ? result1.ToString() : "Product not found.");

            // Step 3: Binary Search
            Console.WriteLine("\nBinary Search:");
            var result2 = BinarySearch(products, searchId);
            Console.WriteLine(result2 != null ? result2.ToString() : "Product not found.");

            Console.ReadLine();
        }
    }
}
