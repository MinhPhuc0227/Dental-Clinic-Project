using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public enum ServiceStatus
    {
        Active,
        Inactive
    }

    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public ServiceStatus Status { get; set; } = ServiceStatus.Active;
    }
}
