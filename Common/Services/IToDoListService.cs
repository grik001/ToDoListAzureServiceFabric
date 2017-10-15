using Common.Models;
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public interface IToDoListService : IService
    {
        Task<IEnumerable<ToDoListContainer>> GetAllToDoLists();
        Task AddToDoList(ToDoListContainer toDoList);
    }
}
