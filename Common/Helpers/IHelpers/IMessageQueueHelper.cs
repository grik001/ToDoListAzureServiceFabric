﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers.IHelpers
{
    public interface IMessageQueueHelper
    {
        void PushMessage<T>(ApplicationConfig config, T message, string queueName);
        Task ReadMessages<T>(ApplicationConfig config, Action<T> actionOnReceive, string queueName);
    }
}
