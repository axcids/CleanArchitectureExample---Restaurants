using MediatR;
using Restaurants.Application.Orders.Dtos;

namespace Restaurants.Application.Orders.Queries.GetAllOrders; 
public class GetAllOrdersQuery : IRequest<IEnumerable<OrderDtos>> {

    

}
