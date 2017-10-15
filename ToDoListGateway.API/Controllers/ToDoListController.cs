using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common.Services;
using Common.Models;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace ToDoListGateway.API.Controllers
{
    [Route("api/[controller]")]
    public class ToDoListController : Controller
    {
        private readonly IToDoListService _toDoListService;

        public ToDoListController()
        {
            _toDoListService = ServiceProxy.Create<IToDoListService>(
                new Uri("fabric:/ToDoListAzureServiceFabric/ToDoListInteractionService"), new ServicePartitionKey(0)
            );
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<ToDoListContainer>> Get()
        {
            try
            {
                IEnumerable<ToDoListContainer> allLists = await _toDoListService.GetAllToDoLists();
                return allLists;
            }
            catch (Exception ex)
            {
            }

            return null;
        }

        [HttpPost]
        public async Task Post(ToDoListContainer toDoList)
        {
            try
            {
                await _toDoListService.AddToDoList(toDoList);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
