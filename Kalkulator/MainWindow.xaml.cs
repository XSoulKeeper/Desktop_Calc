using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace Kalkulator
{
    public partial class MainWindow : Window
    {
        public static SoundManager soundManager = new SoundManager();
        
        public MainWindow()
        {
            InitializeComponent();
            var image = new BitmapImage(new Uri("pack://application:,,,/Kalkulator;component/Resources/background.gif"));
            ImageBehavior.SetAnimatedSource(BackgroundGif, image);
            CalculatorContent.Content = new ProstyCalc();
            CalculatorContent.Content = new NaukCalc();
        }


        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPopup.IsOpen = true;
            Storyboard rotateRight = (Storyboard)MenuButton.FindResource("RotateRightStoryboard");
            if (rotateRight != null)
            {
                rotateRight.Begin();
            }
        }

        private void ModeButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            switch (button?.Tag?.ToString())
            {
                case "Prosty":
                    CalculatorContent.Content = new ProstyCalc();
                    break;
                case "Naukowy":
                    CalculatorContent.Content = new NaukCalc();
                    break;
                case "Programistyczny":
                    CalculatorContent.Content = new TextBlock { Text = "Kalkulator programistyczny (w budowie)", FontSize = 24, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
                    break;
            }
            MenuPopup.IsOpen = false;
            Storyboard rotateLeft = (Storyboard)MenuButton.FindResource("RotateLeftStoryboard");
            if (rotateLeft != null)
            {
                rotateLeft.Begin();
            }
        }
    }
}