using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Buttons_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random _random;
        public MainWindow()
        {
            InitializeComponent();

            _random = new Random();
        }

        private SolidColorBrush ColorRandomizer()
        {
            var r = Convert.ToByte(_random.Next(0, 256));
            var g = Convert.ToByte(_random.Next(0, 256));
            var b = Convert.ToByte(_random.Next(0, 256));

            return new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        private void Button_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (e.ChangedButton)
            {
                case MouseButton.Left:
                    {
                        ChangeButtonColor(sender, e);
                        MessageBox.Show($"Button {(sender as Button)?.Content} has been clicked", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    break;
                case MouseButton.Right:
                    ChangeWindowTitle(sender, e);
                    DeleteButton(sender, e);
                    break;
            }
        }

        private void ChangeButtonColor(object sender, EventArgs e)
        {
            if (!(sender is Button button))
                return;

            button.Background = ColorRandomizer();
        }

        private void ChangeWindowTitle(object sender, EventArgs e)
        {
            if (!(sender is Button button))
                return;

            this.Title = $"Deleted:{button.Content.ToString()}";
        }

        private void DeleteButton(object sender, EventArgs e)
        {
            if (!(sender is Button button))
                return;

            Panel.Children.Remove(button);
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in Panel.Children)
            {
                if (element is Button button)
                    button.Background = ColorRandomizer();
            }
        }
    }
}