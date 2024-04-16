using Android.App;
using Android.OS;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Platform;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.Picker;
using System.Collections.ObjectModel;

namespace PickerNativeEmbedding
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        MauiContext? _mauiContext;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            MauiAppBuilder builder = MauiApp.CreateBuilder();
            builder.UseMauiEmbedding<Microsoft.Maui.Controls.Application>();
            builder.ConfigureSyncfusionCore();
            MauiApp mauiApp = builder.Build();
            _mauiContext = new MauiContext(mauiApp.Services, this);

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

            Android.Views.View view = picker.ToPlatform(_mauiContext);

            // Set our view from the "main" layout resource
            SetContentView(view);
        }
    }
}