using System;
using System.Collections.ObjectModel;
using System.Windows;



namespace Shapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Shape> ListOfShapes { get; } = new();
        public MainWindow()
        {
            InitializeComponent();
            ListOfShapes.Clear();
            DataContext = this;
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            string selected = comboBox.Text;

            if (selected == "Circle")
            {
                if (double.TryParse(textBoxRadius.Text, out double r) 
                    && string.IsNullOrEmpty(textBoxHeight.Text)
                    && string.IsNullOrEmpty(textBoxASide.Text)
                    && string.IsNullOrEmpty(textBoxBSide.Text))
                {
                    ListOfShapes.Add(new Shape() { Name = "Circle", Radius = r, Area = Math.Round(Math.PI * Math.Pow(r, 2), 2) });
                }
            }
            else if (selected == "Rectangle")
            {
                if (double.TryParse(textBoxASide.Text, out double a)
                    && double.TryParse(textBoxBSide.Text, out double b) 
                    && string.IsNullOrEmpty(textBoxHeight.Text)
                    && string.IsNullOrEmpty(textBoxRadius.Text))
                {
                    ListOfShapes.Add(new Shape() { Name = "Rectangle", ASide = a, BSide = b, Area = Math.Round(a * b, 2) });
                }
            }
            else if (selected == "Triangle")
            {
                if (double.TryParse(textBoxASide.Text, out double a)
                    && double.TryParse(textBoxHeight.Text, out double h)
                    && string.IsNullOrEmpty(textBoxRadius.Text)
                    && string.IsNullOrEmpty(textBoxBSide.Text))
                {
                    ListOfShapes.Add(new Shape() { Name = "Triangle", ASide = a, Height = h, Area = Math.Round((a * h) / 2, 2) });
                }
            }

            double areaSum = 0;
            foreach (var shape in ListOfShapes)
            {
                areaSum += shape.Area;
            }
            textBlockArea.Text = Convert.ToString(areaSum);
        }
    }
}
