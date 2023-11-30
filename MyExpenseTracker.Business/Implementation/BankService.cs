using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyExpenseTracker.Business.Core;
using MyExpenseTracker.Models;
using MyExpenseTracker.Repository.Interfaces;

namespace MyExpenseTracker.Business.Implementation
{
    public class BankService
    {
        private IRepository<Bank> bankRepository;
        public BankService(IRepository<Bank> bankRepository) 
        {
            this.bankRepository = bankRepository;
        }

        private async Task<ServiceResult<Bank>> Insert(Bank bank)
        {
            this.bankRepository.Add(bank);
            await this.bankRepository.SaveAsync();
            return ServiceResult<Bank>.Create(200, "Record inserted Successfully!", bank);
        }

        private async Task<ServiceResult<Bank>> Update(int id, Bank bank)
        {
            var result = this.bankRepository.Get(x => x.Id == id);
            if (result != null)
            {
                result.Name = bank.Name;
                result.Acrynonym = bank.Acrynonym;
                result.Type = bank.Type;
                this.bankRepository.Update(result);
                await this.bankRepository.SaveAsync();
                return ServiceResult<Bank>.Create(200, "Record updated Successfully!", result);
            }
            else
            {
                return ServiceResult<Bank>.Create(400, "Record not found");
            }
        }

        private async Task<ServiceResult<Bank>> Delete(int id)
        {
            var result = this.bankRepository.Get(x => x.Id == id);
            if (result != null)
            {
                this.bankRepository.Remove(result);
                await this.bankRepository.SaveAsync();
                return ServiceResult<Bank>.Create(200, "Record updated Successfully!", result);
            }
            else
            {
                return ServiceResult<Bank>.Create(400, "Record not found");
            }
        }

        private async Task<ServiceResult<Bank>> Select(int id)
        {
            await Task.CompletedTask;
            var result = this.bankRepository.Get(x => x.Id == id);
            if (result != null)
            {
                return ServiceResult<Bank>.Create(200, "Record found Successfully!", result);
            }
            else
            {
                return ServiceResult<Bank>.Create(400, "Record not found");
            }
        }

        private async Task<ServiceResult<IEnumerable<Bank>>> Search(string name, string type)
        {
            await Task.CompletedTask;
            var result = new List<Bank>();
            
            if (!string.IsNullOrEmpty(name))
            {
                if (!string.IsNullOrEmpty(type))
                {
                    result = this.bankRepository.GetRange(x => (x.Name.ToUpper().StartsWith(name.ToUpper()) || x.Acrynonym.ToUpper().StartsWith(name.ToUpper()))
                        && x.Type.ToUpper() == type.ToUpper()).ToList();
                }

                result = this.bankRepository.GetRange(x => (x.Name.ToUpper().StartsWith(name.ToUpper()) || x.Acrynonym.ToUpper().StartsWith(name.ToUpper()))).ToList();
            }
            else if (!string.IsNullOrEmpty(type))
            {
                result = this.bankRepository.GetRange(x => x.Type.ToUpper() == type.ToUpper()).ToList();
            }

            if (result != null)
            {
                return ServiceResult<IEnumerable<Bank>>.Create(200, "Record found Successfully!", result);
            }
            else
            {
                return ServiceResult<IEnumerable<Bank>>.Create(400, "Record not found");
            }
        }
    }
}
