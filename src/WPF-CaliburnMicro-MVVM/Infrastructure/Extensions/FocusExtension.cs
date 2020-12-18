using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF_CaliburnMicro_MVVM.Infrastructure.Extensions
{
    public static class FocusExtension
    {
        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.RegisterAttached("IsFocused", typeof(bool?), typeof(FocusExtension), new FrameworkPropertyMetadata(IsFocusedChanged));

        public static bool? GetIsFocused(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            return (bool?)element.GetValue(IsFocusedProperty);
        }

        public static void SetIsFocused(DependencyObject element, bool? value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            element.SetValue(IsFocusedProperty, value);
        }

        private static void IsFocusedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;

            if (e.OldValue == null)
            {
                element.GotFocus += FrameworkElementGotFocus;
                element.LostFocus += FrameworkElement_LostFocus;
            }

            if (!element.IsVisible)
            {
                element.IsVisibleChanged += FrameworkElementIsVisibleChanged;
            }

            if ((bool)e.NewValue)
            {
                var textBox = element as TextBox;
                if (textBox != null)
                    textBox.SelectAll();
                element.Focus();
            }
        }

        private static void FrameworkElementIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var fe = (FrameworkElement)sender;
            if (fe.IsVisible && (bool)((FrameworkElement)sender).GetValue(IsFocusedProperty))
            {
                fe.IsVisibleChanged -= FrameworkElementIsVisibleChanged;
                fe.Focus();
            }
        }

        private static void FrameworkElementGotFocus(object sender, RoutedEventArgs e)
        {
            ((FrameworkElement)sender).SetValue(IsFocusedProperty, true);
        }

        private static void FrameworkElement_LostFocus(object sender, RoutedEventArgs e)
        {
            ((FrameworkElement)sender).SetValue(IsFocusedProperty, false);
        }
    }
}
