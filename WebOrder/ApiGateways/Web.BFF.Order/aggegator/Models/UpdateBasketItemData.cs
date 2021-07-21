namespace aggegator.Models
{
    public class UpdateBasketItemData
    {
        public string BasketItemId { get; set; }

        public int NewQty { get; set; }

        public UpdateBasketItemData()
        {
            NewQty = 0;
        }
    }
}
