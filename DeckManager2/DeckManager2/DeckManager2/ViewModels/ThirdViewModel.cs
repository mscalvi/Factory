using DeckManager2.ViewModels;
using System;

namespace DeckManager2.ViewModels;

public class ThirdPageViewModel : PageViewModelBase
{
    // The message to display
    public string Message => "Done";

    // This is the last page, so we cannot navigate next in our sample.
    public override bool CanNavigateNext
    {
        get => false;
        protected set => throw new NotSupportedException();
    }

    // We navigate back form this page in any case
    public override bool CanNavigatePrevious
    {
        get => true;
        protected set => throw new NotSupportedException();
    }
}