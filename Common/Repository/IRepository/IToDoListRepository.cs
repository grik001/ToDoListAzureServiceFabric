using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository.IRepository
{
    public interface IToDoListRepository
    {
        Task<IEnumerable<ToDoListContainer>> GetAllToDoLists();
        Task AddToDoList(ToDoListContainer toDoList);
    }
}

