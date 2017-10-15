using Common.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Data.Collections;
using System.Linq;
using System.Threading;

namespace Common.Repository
{
    public class ToDoListRepository : IToDoListRepository
    {
        private IReliableStateManager _stateManager;

        public ToDoListRepository(IReliableStateManager stateManager)
        {
            _stateManager = stateManager;
        }

        public async Task AddToDoList(ToDoListContainer toDoList)
        {
            var result = await _stateManager.GetOrAddAsync<IReliableDictionary<Guid, ToDoListContainer>>("ToDoListRepo");

            using (var tx = _stateManager.CreateTransaction())
            {
                await result.AddOrUpdateAsync(tx, toDoList.ID, toDoList, (id, value) => toDoList);

                await tx.CommitAsync();
            }
        }

        public async Task<IEnumerable<ToDoListContainer>> GetAllToDoLists()
        {
            var result = new List<ToDoListContainer>();

            using (var ts = _stateManager.CreateTransaction())
            {
                var data = await _stateManager.GetOrAddAsync<IReliableDictionary<Guid, ToDoListContainer>>("ToDoListRepo");
                var allData = await data.CreateEnumerableAsync(ts, EnumerationMode.Unordered);

                using (var enumerator = allData.GetAsyncEnumerator())
                {
                    while (await enumerator.MoveNextAsync(CancellationToken.None))
                    {
                        KeyValuePair<Guid, ToDoListContainer> current = enumerator.Current;
                        result.Add(current.Value);
                    }
                }
            }

            return result;
        }
    }
}
