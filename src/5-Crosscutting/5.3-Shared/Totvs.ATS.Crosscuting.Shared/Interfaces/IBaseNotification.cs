﻿using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ATS.Shared.Interfaces
{
    public interface IBaseNotification
    {
        IReadOnlyCollection<Notification> Notifications { get; }
        void AddNotifications(IReadOnlyCollection<Notification> notifications);
        bool IsValid { get; }
    }
}
