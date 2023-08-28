# How-to-remove-the-indicator-icon-from-.NET-MAUI-SfChipGroup
This sample explains how to remove the selection indicator icon in the .NET MAUI ChipGroup (SfChipGroup) when ChipType is Filter.

### Steps

### Step 1: Enable the ChipType as a Filter for multiple selections

To select multiple chips in the ChipGroup, set the ChipType property to “Filter”. This configuration allows users to choose more than one chip within the group.

XAML
```
<chip:SfChipGroup ChipType="Filter">
        ...
</chip:SfChipGroup>
```
### Step 2: Remove the Selection indicator icon of ChipGroup:

You can remove the indicator icon from the .NET MAUI ChipGroup by using the ItemTemplate property. Inside this template, add the Chip control as the content. It will show the language names only.

XAML
```
 <chip:SfChipGroup x:Name="chipGroup"
                   ChipType="Filter">
            <chip:SfChipGroup.ItemTemplate>
                <DataTemplate>
                    <chip:SfChip Text="{Binding Name}" />
                </DataTemplate>
            </chip:SfChipGroup.ItemTemplate>
 </chip:SfChipGroup>
 ```
### Step 3: Added the Visual States for the Selected Chip Background

To set the background color for the selected chips, you can use the visual states for the chip group as given below. Also, set the chip’s BackgroundColor of SfChip to transparent, because we have dynamically changed the ChipBackground of ChipGroup items using Visual States. Additionally, Setting InputTransparent as false in Chip to disables inputs, and its children should receive input.

XAML
```
 <chip:SfChipGroup x:Name="chipGroup"
                   ChipType="Filter">
            <VisualStateManager.VisualStateGroups>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal">
                        <VisualState.Setters>
                            <Setter Property="ChipBackground" Value="White" />
                        </VisualState.Setters>
                    </VisualState>
                    <VisualState x:Name="Selected">
                        <VisualState.Setters>
                            <Setter Property="ChipBackground" Value="#512dcd" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateManager.VisualStateGroups>
            <chip:SfChipGroup.ItemTemplate>
                <DataTemplate>
                    <chip:SfChip InputTransparent="True"
                                 BackgroundColor="Transparent">
                        ...
                    </chip:SfChip>
                </DataTemplate>
            </chip:SfChipGroup.ItemTemplate>
 </chip:SfChipGroup>
 ```
### Step 4: Change the Selected chip TextColor

Add the DataTriggers to change the TextColor of the Chip based on the IsSelected property from the Language class. You can set the value for the IsSelected property in the SelectionChanged Event.

XAML
```
 <chip:SfChipGroup x:Name="chipGroup"
                   ChipType="Filter"
                   ItemsSource="{Binding Languages}"
                   SelectionChanged="OnSelectionChanged">
            <VisualStateManager.VisualStateGroups>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal">
                        <VisualState.Setters>
                            <Setter Property="ChipBackground" Value="White" />
                        </VisualState.Setters>
                    </VisualState>
                    <VisualState x:Name="Selected">
                        <VisualState.Setters>
                            <Setter Property="ChipBackground" Value="#512dcd" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateManager.VisualStateGroups>
            <chip:SfChipGroup.ItemTemplate>
                <DataTemplate>
                    <chip:SfChip Text="{Binding Name}"
                                 InputTransparent="True"
                                 BackgroundColor="Transparent">
                        <chip:SfChip.Triggers>
                            <DataTrigger TargetType="chip:SfChip" Binding="{Binding IsSelected}" Value="True">
                                <Setter Property="TextColor" Value="White"/>
                            </DataTrigger>
                            <DataTrigger TargetType="chip:SfChip" Binding="{Binding IsSelected}" Value="False">
                                <Setter Property="TextColor" Value="Red"/>
                            </DataTrigger>
                        </chip:SfChip.Triggers>
                    </chip:SfChip>
                </DataTemplate>
            </chip:SfChipGroup.ItemTemplate>
 </chip:SfChipGroup>
```   
### SelectionChanged Event

    private void OnSelectionChanged(object sender, Syncfusion.Maui.Core.Chips.SelectionChangedEventArgs e)
    {
        if (e.AddedItem != null)
        {
            (e.AddedItem as Language).IsSelected= true;
        }

        if (e.RemovedItem != null)
        {
            (e.RemovedItem as Language).IsSelected= false;
        }
    }
### Populate chip items
```
    public class Language : INotifyPropertyChanged
    {
        public string Name
        {
            get;
            set;
        }

        private bool isSelected= false;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected= value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsSelected"));
            }
        }
    }
```
```
public class ViewModel
{
    public ObservableCollection<Language> Languages { get; set; }

    public ViewModel()
    {
        this.Languages = new ObservableCollection<Language>();

        Languages.Add(new Language() { Name = "C#" });
        Languages.Add(new Language() { Name = "Python" });
        Languages.Add(new Language() { Name = "Java" });
        Languages.Add(new Language() { Name = "Js" });
    }
}
```
## Requirements to run the demo

* [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)

## Troubleshooting

### Path too long exception

If you are a facing path too long exception when building this example project, close Visual Studio rename the repository to short, and build the project.