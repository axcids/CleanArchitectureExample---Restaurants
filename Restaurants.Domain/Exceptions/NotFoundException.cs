namespace Restaurants.Domain.Exceptions {
    public class NotFoundException(string message) : Exception(message){
        //I have applied this method only in the GetOrderById query Handler *******************************************
        //There is a dynamic way to for this class in the course meterials.
    }
}
