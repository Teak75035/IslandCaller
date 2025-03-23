using System.Windows.Controls;
namespace IslandCaller.Controls.NotificationProviders;

public partial class IslandCallerNotificationControl : UserControl
{
    public IslandCallerNotificationControl(string studentName)
    {
        InitializeComponent();
        RandomStudent.Text = studentName;
    }
}