using WebOrder.Web.Shopping.HttpAggregator.Models;
using System.Threading.Tasks;

namespace WebOrder.Web.Shopping.HttpAggregator.Services
{
    public interface IOrderApiClient
    {
        Task<OrderData> GetOrderDraftFromBasketAsync(BasketData basket);
    }
}