﻿using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.Dtos; 
public class DishDtos {
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; } 
    public int KiloCalories { get; set; }

    public static DishDtos FromEntity(Dish dish) {
        if (dish == null) return null;
        return new DishDtos {
            Id = dish.Id,
            RestaurantId = dish.RestaurantId,
            Name = dish.Name,
            Description = dish.Description,
            Price = dish.Price,
            KiloCalories = dish.KiloCalories
        };

    }
}
