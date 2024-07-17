using AutoMapper;
using CustomerService.AsyncDataService;
using CustomerService.Data;
using CustomerService.Dtos;
using CustomerService.Model;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _repository;
        private readonly IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public CustomerController(
            ICustomerRepo repository, 
            IMapper mapper, 
            IMessageBusClient messageBusClient)
        {
            _repository = repository;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerReadDto>> GetAllCustomers()
        {
            Console.WriteLine("--> Looking for customers");

            var customers = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(customers));
        }

        [HttpPost]
        public ActionResult<CustomerReadDto> CreateCustomer(CustomerCreateDto customerCreateDto)
        {
            var customerModel = _mapper.Map<Customer>(customerCreateDto);
            _repository.CreateCustomer(customerModel);
            _repository.SaveChanges();

            var customerReadDto = _mapper.Map<CustomerReadDto>(customerModel);

            try
            {
                var customerPublishedDto = _mapper.Map<CustomerPublishedDto>(customerReadDto);
                customerPublishedDto.Event = "Customer_Published";
                _messageBusClient.PublishNewCustomer(customerPublishedDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send asynchronously: {ex.Message}");
            }

            return Ok(customerReadDto);
        }
    }
}
