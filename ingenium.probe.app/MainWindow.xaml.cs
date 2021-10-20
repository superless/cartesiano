using ingenium.probe.library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ingenium.probe.app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            lblInfo.Content = $"{e.GetPosition(mainCanvas).X},{e.GetPosition(mainCanvas).Y}";
        }

        private void mainCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlanoCartesiano(e.GetPosition(mainCanvas).X, e.GetPosition(mainCanvas).Y);
        }

        private void mainCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            mainCanvas.Children.Clear();
        }

        private void PlanoCartesiano(double x, double y) {

            var (origenX, finalX, origenY, finalY, x_points, y_points) = PlotDrawing.GetPlot(Convert.ToInt32(x), Convert.ToInt32(y), 20, 10);

            var lnY = new Line
            {
                X1 = origenY.X,
                Y1 = origenY.Y,
                X2 = finalY.X,
                Y2 = finalY.Y,
                Stroke = Brushes.Coral,
                StrokeThickness = 2
            };

            var lnX = new Line
            {
                X1 = origenX.X,
                Y1 = origenX.Y,
                X2 = finalX.X,
                Y2 = finalX.Y,
                Stroke = Brushes.Coral,
                StrokeThickness = 2
            };

            foreach (var lineX in x_points)
            {
                var ln = new Line
                {
                    X1 = lineX.X,
                    Y1 = lineX.Y-3,
                    X2 = lineX.X,
                    Y2 = lineX.Y+3,
                    Stroke = Brushes.Coral,
                    StrokeThickness = 2
                };
                mainCanvas.Children.Add(ln);
            }

            foreach (var lineY in y_points)
            {
                var ln = new Line
                {
                    X1 = lineY.X -3,
                    Y1 = lineY.Y,
                    X2 = lineY.X + 3,
                    Y2 = lineY.Y,
                    Stroke = Brushes.Coral,
                    StrokeThickness = 2
                };
                mainCanvas.Children.Add(ln);
            }

            mainCanvas.Children.Add(lnY);
            mainCanvas.Children.Add(lnX);

        }
    }
}
