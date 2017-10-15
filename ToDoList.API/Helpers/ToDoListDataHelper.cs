using Common.Models;
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.API.Helpers
{
    public interface IToDoListDataHelper : IService
    {
        Task<IEnumerable<ToDoListContainer>> GetAllToDoLists();
        Task AddToDoList(ToDoListContainer toDoList);
    }
}
