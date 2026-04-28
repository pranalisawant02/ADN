namespace EventManager.Services
{
    public class BookingService
    {
        public int CalculateTotalPrice(int ticketPrice, int quantity)
        {
            return ticketPrice * quantity;
        }
    }
}