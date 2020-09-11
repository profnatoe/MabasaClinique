using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinique.Service
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public DateTime Time { get; set; }
    }
}
