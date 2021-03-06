﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IcyWind.Core
{
    public static class LanguageHelper
    {
        public static ResourceDictionary MainLanguage = new ResourceDictionary();

        public static void SetResource(string language)
        {
            MainLanguage.Source = new Uri($"pack://application:,,,/IcyWind.Languages;component/{language}.xaml");
        }

        public static string ShortNameToString(string shortName)
        {
            return (string) MainLanguage[shortName];
        }
    }
}
