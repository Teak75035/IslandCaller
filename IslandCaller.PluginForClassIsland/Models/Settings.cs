using CommunityToolkit.Mvvm.ComponentModel;

namespace IslandCaller.Models;

public class Settings : ObservableRecipient
{
    private bool _isHoverShow = true;

    public bool IsHoverShow
    {
        get => _isHoverShow;
        set
        {
            if (value == _isHoverShow) return;
            _isHoverShow = value;
            OnPropertyChanged();
        }
    }

    bool _isBreakProofEnabled;
    public bool IsBreakProofEnabled {
        get => _isBreakProofEnabled;
        set {
            if (value == _isBreakProofEnabled) return;
            _isBreakProofEnabled = value;
            OnPropertyChanged();
        }
    }
}