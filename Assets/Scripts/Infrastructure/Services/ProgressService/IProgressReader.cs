using Assets.Scripts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services.ProgressService
{
    public interface IProgressReader
    {
        void LoadProgress(PlayerProgress playerProgress);
    }
}
