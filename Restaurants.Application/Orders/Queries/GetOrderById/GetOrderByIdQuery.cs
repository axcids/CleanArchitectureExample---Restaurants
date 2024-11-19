using MediatR;
using Restaurants.Application.Orders.Dtos;

namespace Restaurants.Application.Orders.Queries.GetOrderById; 
public class GetOrderByIdQuery : IRequest<OrderDtos>{
    public int Id { get; init; }
}
