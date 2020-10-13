
namespace BooksAndRestaurant
{
    class Food
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal SubtotalProduct { get; set; }
        public Food(string productName, decimal productPrice,
            int productQuantity)
        {
            Name = productName;
            Price = productPrice;
            Quantity = productQuantity;
            SubtotalProduct = productQuantity * productPrice;
        }
    }
}
