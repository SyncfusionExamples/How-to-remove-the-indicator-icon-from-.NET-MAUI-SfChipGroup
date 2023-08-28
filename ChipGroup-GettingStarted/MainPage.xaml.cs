using Syncfusion.Maui.Core;

namespace ChipGroup_GettingStarted;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        
    }

    private void OnSelectionChanged(object sender, Syncfusion.Maui.Core.Chips.SelectionChangedEventArgs e)
    {
        if (e.AddedItem != null)
        {
            (e.AddedItem as Language).IsSelected = true;
        }

        if (e.RemovedItem != null)
        {
            (e.RemovedItem as Language).IsSelected = false;
        }
    }

}

