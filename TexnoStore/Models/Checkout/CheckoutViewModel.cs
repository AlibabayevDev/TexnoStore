namespace TexnoStore.Models.Checkout
{
    public class CheckoutViewModel : BaseModel
    {
        public ShopCartListViewModel ShopCart { get; set; }
        public OrderDetailsModel OrderDetails { get; set; }
    }
}
