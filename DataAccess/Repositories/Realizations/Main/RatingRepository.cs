using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using DataAccess.Repositories.Realizations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Realizations.Main
{
    public class RatingRepository : RepositoryBase<Rating>, IRatingRepository
    {
        public RatingRepository(PhotoEvaluatorContext context) : base(context)
        {
            
        }
    }
}
