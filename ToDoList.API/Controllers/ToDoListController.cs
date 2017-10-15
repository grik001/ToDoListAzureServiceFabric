using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common.Services;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Client;
using Common.Models;

namespace ToDoList.API.Controllers
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
        public async Task<IEnumerable<ToDoListContainer>>  Get()
        {
            IEnumerable<ToDoListContainer> allLists = await _toDoListService.GetAllToDoLists();
            return allLists;
        }

        [HttpPost]
        public async Task Post(ToDoListContainer toDoList)
        {
            await _toDoListService.AddToDoList(toDoList);
        }
    }
}
