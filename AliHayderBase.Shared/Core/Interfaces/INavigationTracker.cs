using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliHayderBase.Shared.Core.Interfaces
{
    public interface INavigationTracker
    {
        void Record(string uri);
        string? GetPrevious();

    }
}