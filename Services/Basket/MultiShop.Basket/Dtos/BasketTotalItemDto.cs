namespace MultiShop.Basket.Dtos
{
    public class BasketTotalItemDto
    {
        public string UserId { get; set; }
        public string Discount { get; set; }
        public int DicountRate { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        public Decimal Price { get => BasketItems.Sum(x => x.Price * x.Quantity); }

    }
}
