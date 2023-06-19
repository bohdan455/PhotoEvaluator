using DataAccess.Repositories.Realizations.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RatingService
    {
        private readonly RatingRepository _ratingRepository;

        public RatingService(RatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public async Task Rate(long raterId,long userToRate)
        {

        }
    }
}
