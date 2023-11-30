using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenseTracker.Business.Core
{
    public class ServiceResult<T> where T : class
    {
        public int Code { get; set; }

        public string? Message { get; set; }

        public T? Item { get; set; }

        public static ServiceResult<T> Create(int code, string? message)
        {
            Create(code, message, null);
        }

        public static ServiceResult<T> Create(int code, string? message, T? item)
        {
            return new ServiceResult<T>()
            {
                Code = code,
                Message = message,
                Item = item
            };
        }
    }
}
