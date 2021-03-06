﻿using System;
using System.Globalization;
using System.Windows.Data;
using GenderApp.Aggregates;

namespace GenderApp
{
    public class GenderResultConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var genderResult = value as GenderResult;
            if (genderResult == null)
            {
                throw new NotSupportedException();
            }

            return string.Format(CultureInfo.InvariantCulture, "{0} {1}", genderResult.FirstName, genderResult.LastName);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
