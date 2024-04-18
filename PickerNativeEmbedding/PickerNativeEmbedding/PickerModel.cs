using System.Collections.ObjectModel;

namespace PickerNativeEmbedding
{
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
}
