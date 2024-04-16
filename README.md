# How to integrate .NET MAUI Picker (SfPicker) with android native embedding application
In this article, you will learn how to create a [.NET MAUI Picker](https://www.syncfusion.com/maui-controls/maui-picker) native embedded Android application by following the step by step process explained below.

**Step 1:**
Create a .NET Android application and install the [Syncfusion.Maui.Picker](https://www.nuget.org/packages/Syncfusion.Maui.Picker) nuget package using the [nuget.org](https://www.nuget.org/).

**Step 2:**
In the project file of the native application, add the tag `<UseMaui>true</UseMaui>` to enable the .NET MAUI support as demonstrated below.
 
**[XML]:**
 ```xml
<PropertyGroup>
	<Nullable>enable</Nullable>
	<ImplicitUsings>enable</ImplicitUsings>
	<UseMaui>true</UseMaui>
</PropertyGroup>
 ```
 
**Step 3:**
Initialize .NET MAUI in the native app project by creating a **MauiAppBuilder** object and using the **UseMauiEmbedding** function. Then, use the **Build()** method on the **MauiAppBuilder** object to build a **MauiApp** object. Finally, create a **MauiContext** object from the MauiApp object to convert .NET MAUI controls to native types.

**[C#]:**
 ```csharp
MauiContext? _mauiContext;
protected override void OnCreate(Bundle? savedInstanceState)
{
    base.OnCreate(savedInstanceState);
    MauiAppBuilder builder = MauiApp.CreateBuilder();
    builder.UseMauiEmbedding<Microsoft.Maui.Controls.Application>();
    builder.ConfigureSyncfusionCore();
    MauiApp mauiApp = builder.Build();
    _mauiContext = new MauiContext(mauiApp.Services, this);
}
 ```
 
**Step 4:**
Create a model class to manage the collection of data and provide customizable data source for the picker.
 
**[C#]:**
 ```csharp
public class PickerModel
{
    private ObservableCollection<object> dataSource = new ObservableCollection<object>()
    {
        "Pink", "Green", "Blue", "Yellow", "Orange", "Purple", "Sky Blue", "Pale Green"
    };

    public ObservableCollection<object> DataSource
    {
        get
        {
            return dataSource;
        }
        set
        {
            dataSource = value;
        }
    }

    public PickerModel()
    {

    }
}
 ```
 
**Step 5:**
Create a view model class that initializes an instance of **PickerModel**.

 **[C#]:**
 ```csharp
public class PickerViewModel
{
    public PickerModel PickerModel { get; set; }
    public PickerViewModel()
    {
        this.PickerModel = new PickerModel();
    }
}
 ```

**Step 6:**
Configure the SfPicker by customizing the header with [PickerHeaderView](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Picker.PickerHeaderView.html) and bind the data source to the column with the [PickerColumn](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Picker.PickerColumn.html). To enable the HeaderView, set the [Height](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Picker.PickerHeaderView.html#Syncfusion_Maui_Picker_PickerHeaderView_HeightProperty) to the [PickerHeaderView](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Picker.PickerHeaderView.html). Follow the below code snippet for better understanding.
 
**[C#]:**
 ```csharp
protected override void OnCreate(Bundle? savedInstanceState)
{
    PickerModel info = new PickerModel();
    SfPicker picker = new SfPicker()
    {
        HeaderView = new PickerHeaderView()
        {
            Text = "Select a color",
            Height = 60,
            Background = Colors.Orange,
        },

        Columns = new ObservableCollection<PickerColumn>()
        {
            new PickerColumn()
            {
                HeaderText = "Colors",
                ItemsSource = info.DataSource,
                SelectedIndex = 4,
            }
        },
    };  
}
 ```

**Step 7:**
Convert the picker control to a platform-specific view for the MAUI framework and set this view as the content view for the current Android activity.

 **[C#]:**
 ```csharp
protected override void OnCreate(Bundle? savedInstanceState)
{
    Android.Views.View view = picker.ToPlatform(_mauiContext);

    // Set our view from the "main" layout resource
    SetContentView(view);
}
 ```
 
**Output:**

![Picker.png](https://syncfusion.bolddesk.com/kb/agent/attachment/article/15082/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjE4MDY4Iiwib3JnaWQiOiIzIiwiaXNzIjoic3luY2Z1c2lvbi5ib2xkZGVzay5jb20ifQ.lvpfVwiE6YqeAozIbXsxgrJfNciu3WodgD0mmIRCB_M)
