using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.Defaults
{
    public enum RolesEnum
    {
        Admin = 1,
        Customer,
        Employee,
        CustomUser
    }

    public enum PriceTypeEnum
    {
        Service = 1,
        AddOn
    }

    public enum BookingType
    {
        Pending=1,
        Complete,
        InProcessing

    }


}