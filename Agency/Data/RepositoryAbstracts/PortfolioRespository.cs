using Core.Models;
using Core.RepositoryAbstracts;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.RepositoryAbstracts
{
    public class PortfolioRespository : GenericRepository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRespository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
