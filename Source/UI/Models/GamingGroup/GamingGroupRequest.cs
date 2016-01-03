﻿using BusinessLogic.Models.Utility;
using System;

namespace UI.Models.GamingGroup
{
    public class GamingGroupRequest : IDateRangeFilter
    {
        public readonly DateTime DefaultFromDate = new DateTime(2010, 1, 1);

        public GamingGroupRequest()
        {
            FromDate = DefaultFromDate;
            ToDate = DateTime.UtcNow;
        }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}