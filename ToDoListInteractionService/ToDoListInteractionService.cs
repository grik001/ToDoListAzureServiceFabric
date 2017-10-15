using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Common.Repository.IRepository;
using Common.Repository;
using Common.Helpers.IHelpers;
using Common.Helpers;
using Common.Models;
using Common.Services;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;

namespace ToDoListInteractionService
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class ToDoListInteractionService : StatefulService, IToDoListService
    {
        IToDoListRepository _repo = null;
        IMessageQueueHelper _mqHelper = null;
        ApplicationConfig _config = new ApplicationConfig();

        public ToDoListInteractionService(StatefulServiceContext context)
            : base(context)
        { }

        public async Task AddToDoList(ToDoListContainer toDoList)
        {
            await _repo.AddToDoList(toDoList);
        }

        public async Task<IEnumerable<ToDoListContainer>> GetAllToDoLists()
        {
            return await _repo.GetAllToDoLists();
        }

        /// <summary>
        /// Optional override to create listeners (e.g., HTTP, Service Remoting, WCF, etc.) for this service replica to handle client or user requests.
        /// </summary>
        /// <remarks>
        /// For more information on service communication, see https://aka.ms/servicefabricservicecommunication
        /// </remarks>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new[]
            {
              new ServiceReplicaListener(context => this.CreateServiceRemotingListener(context))
            };
        }

        /// <summary>
        /// This is the main entry point for your service replica.
        /// This method executes when this replica of your service becomes primary and has write status.
        /// </summary>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service replica.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            _repo = new ToDoListRepository(this.StateManager);
            //_mqHelper = new RabbitMQHelper();

            //await _mqHelper.ReadMessages<ToDoListContainer>(_config, StartNewToDoList, "ToDoList");
        }

        private void StartNewToDoList(ToDoListContainer toDoList)
        {

        }
    }
}
