using MVP_Tema3.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MVP_Tema3.Converters
{
    class NotaConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new Nota()
            {
                notaID = int.Parse(values[0].ToString()),
                elevID = int.Parse(values[1].ToString()),
                materieID = int.Parse(values[2].ToString()),
                nota1 = double.Parse(values[3].ToString())
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            Nota nota = value as Nota;
            object[] result = new object[4] { nota.notaID, nota.elevID,nota.materieID,nota.nota1 };
            return result;
        }
    }
}
