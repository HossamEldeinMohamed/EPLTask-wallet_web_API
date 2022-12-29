using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public class Response
    {
        public int Code { get; set; }
        public object? Data { get; set; }
        public string? Message { get; set; }
    }
}
