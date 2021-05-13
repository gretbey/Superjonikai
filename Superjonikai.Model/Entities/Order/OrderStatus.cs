using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.Entities.Order
{
    public enum OrderStatus
    {
        AwaitingPayment,
        Paid,
        Processing,
        Completed
    }
}
