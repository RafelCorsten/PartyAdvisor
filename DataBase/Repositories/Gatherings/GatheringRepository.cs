using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;
using Domain.Entities.Interfaces;

namespace DataBase.Repositories.Gatherings
{
    public class GatheringRepository : Repository<Gathering>, IGatheringRepository
    {
        public GatheringRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
