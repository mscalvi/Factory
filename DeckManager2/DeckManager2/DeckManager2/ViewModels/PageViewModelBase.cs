using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckManager2.ViewModels
{
    public abstract class PageViewModelBase : ViewModelBase
    {
        public abstract bool CanNavigateNext { get; protected set; }
        public abstract bool CanNavigatePrevious { get; protected set; }
    }
}
