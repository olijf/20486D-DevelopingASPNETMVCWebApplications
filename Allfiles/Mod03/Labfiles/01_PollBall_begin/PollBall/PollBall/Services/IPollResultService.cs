using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollBall.Services
{
    public interface IPollResultService
    {
        void AddVote(SelectedGame game);
        SortedDictionary<SelectedGame, int> GetVoteResult();
    }
}
