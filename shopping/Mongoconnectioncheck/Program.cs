using MongoDB.Bson;
using MongoDB.Driver;
using System;

using static System.Runtime.InteropServices.JavaScript.JSType;

public class Product
{
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    // Add other properties as needed
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var client = new MongoClient("mongodb://localhost:2717"); // Adjust the connection string as needed
            var database = client.GetDatabase("catalogdb"); // Replace with your database name
            var productCollection = database.GetCollection<Product>("Products"); // Replace with your collection name

            bool existProduct = productCollection.Find(p => true).Any();

            if (existProduct)
            {
                Console.WriteLine("There are products in the collection.");
            }
            else
            {
                Console.WriteLine("There are no products in the collection.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        
    }
}
