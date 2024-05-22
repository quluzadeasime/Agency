using Core.Models;
using Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstracts
{
    public interface IPortfolioService
    {
        void Add(Portfolio portfolio);
        void Delete(int id);
        void Update(int id, Portfolio portfolio);
        Portfolio Get(Func<Portfolio, bool> func = null);
        List<Portfolio> GetAll(Func<Portfolio, bool> func = null);
    }
}
