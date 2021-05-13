using MVP_Tema3.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MVP_Tema3.Converters
{
    class ElevConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new ElevVM()
            {
                ElevId = int.Parse(values[0].ToString()),
                Nume = values[1].ToString(),
                NumeUtilizator = values[2].ToString(),
                Parola = values[3].ToString()
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            ElevVM elev = value as ElevVM;
            object[] result = new object[4] { elev.ElevId, elev.Nume, elev.NumeUtilizator, elev.Parola };
            return result;
        }
    }
}
