using MyExpenseTracker.Business.Core;
using MyExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenseTracker.Business.Interfaces
{
    public interface IBankService
    {
        Task<ServiceResult<Bank>> Insert(Bank bank);

        Task<ServiceResult<Bank>> Update(int id, Bank bank);

        Task<ServiceResult<Bank>> Delete(int id);

        Task<ServiceResult<Bank>> Select(int id);

        Task<ServiceResult<IEnumerable<Bank>>> Search(string name, string type);
    }
}
