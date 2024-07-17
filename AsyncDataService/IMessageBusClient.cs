using CustomerService.Dtos;

namespace CustomerService.AsyncDataService
{
    public interface IMessageBusClient
    {
        void PublishNewCustomer(CustomerPublishedDto customerPublishedDto);
    }
}
