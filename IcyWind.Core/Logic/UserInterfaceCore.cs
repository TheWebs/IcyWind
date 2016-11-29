using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace IcyWind.Core.Logic
{
    public static class UserInterfaceCore
    {
        /// <summary>
        /// The main view. This is how the entire thing works
        /// </summary>
        public static ContentControl MainView;

        /// <summary>
        /// All of the loaded usercontrols
        /// </summary>
        private static readonly Dictionary<Type, UserControl> TypeControls = new Dictionary<Type, UserControl>();

        /// <summary>
        /// Changes the view
        /// </summary>
        /// <param name="control">The type of the control <example>LoginControl</example></param>
        /// <param name="args">Any args required to change to that control</param>
        public static void ChangeView(Type control, params object[] args)
        {
            if (!TypeControls.ContainsKey(control))
            {
                TypeControls.Add(control, (UserControl)Activator.CreateInstance(control, args));
            }
            MainView.Content = TypeControls[control];
        }

        /// <summary>
        /// The language resource dictionary
        /// </summary>
        public static ResourceDictionary MainLanguage = new ResourceDictionary();

        /// <summary>
        /// Sets the application language
        /// </summary>
        /// <param name="language">The language you want set</param>
        public static void SetResource(string language)
        {
            MainLanguage.Source = new Uri($"pack://application:,,,/IcyWind.Languages;component/{language}.xaml");
        }

        /// <summary>
        /// Turns a short name into the full text
        /// </summary>
        /// <param name="shortName">The short name from the resource dictionary</param>
        /// <returns>The text in the correct language</returns>
        public static string ShortNameToString(string shortName)
        {
            return (string)MainLanguage[shortName];
        }
    }
}
