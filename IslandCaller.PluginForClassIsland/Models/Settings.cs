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

}