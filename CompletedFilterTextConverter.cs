using System.Globalization;

namespace SmartTaskTracker
{
    internal class CompletedFilterTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool showCompleted = (bool)value;
            return showCompleted ? "Show Incomplete Tasks" : "Show Completed Tasks";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
