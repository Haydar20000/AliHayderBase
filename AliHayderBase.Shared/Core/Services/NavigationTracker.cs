using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliHayderBase.Shared.Core.Interfaces;

namespace AliHayderBase.Shared.Core.Services
{
    public class NavigationTracker : INavigationTracker
    {
        private readonly List<string> _history = new();

        public void Record(string uri)
        {
            if (_history.LastOrDefault() != uri)

                _history.Add(uri);
        }
        public string? GetPrevious()
        {
            if (_history.Count < 2) return null;
            return _history[^2];
        }

    }
}