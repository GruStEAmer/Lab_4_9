using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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

namespace Lab_4_9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int 
            SZ = 25;

        Snake green = new Snake();
        TextBox green_head = new TextBox();

        Snake_blue blue = new Snake_blue();
        TextBox blue_head = new TextBox();
        private
            TextBox Apple = new TextBox {
            Background = new SolidColorBrush(Colors.LightGoldenrodYellow),
            Height = SZ,
            Width = SZ,
        };
        private 
            static Random r = new Random();

        Key flag_g = new Key();
        Key flag_b = new Key();

        public MainWindow()
        {
            InitializeComponent();
            TextBox_Show();
            green.getCanvas(canvas);
            blue.getCanvas(canvas);
        }



        private void TextBox_Show()
        {
            for(int i = 0; i < 1000;i += SZ)
            {
                for(int j = 0;j < 750;j += SZ)
                {
                    TextBox tb = new TextBox
                    {
                        Background = new SolidColorBrush(Colors.SaddleBrown),
                        Width = SZ,
                        Height = SZ,
                        IsReadOnly = true,
                    };
                    Canvas.SetLeft(tb,i);
                    Canvas.SetTop(tb, j);
                    canvas.Children.Add(tb);
                }
            }
            Canvas.SetLeft(Apple, r.Next(0, 30) * 25);
            Canvas.SetTop(Apple, r.Next(0, 30) * 25);
            canvas.Children.Add(Apple);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            green_head = green.head;
            canvas.Children.Add(green_head);

            blue_head = blue.head;
            canvas.Children.Add(blue_head);



            
        }

        private async void Window_KeyDown(object sender, KeyEventArgs e)
        {
            KeyEventArgs key = e;


            if (e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Left || e.Key == Key.Right)
            {
                flag_b = e.Key;
                blue.Move(sender, key);
                if (flag_b == Key.Up || flag_b == Key.Down || flag_b == Key.Left || flag_b == Key.Right)
                {
                    while (flag_b == e.Key)
                    {
                        blue.showSnake();
                        Canvas.SetLeft(blue_head, blue.head_point.X += blue.head_move.X);
                        Canvas.SetTop(blue_head, blue.head_point.Y += blue.head_move.Y);
                        await Task.Delay(500);
                    }
                }
            }

            if (e.Key == Key.W || e.Key == Key.A || e.Key == Key.S || e.Key == Key.D)
            {
                flag_g = e.Key;
                green.Move(sender, key);
                if (flag_g == Key.W || flag_g == Key.A || flag_g == Key.S || flag_g == Key.D)
                {
                    
                    while (flag_g == e.Key)
                    {
                        green.showSnake();
                        Canvas.SetLeft(green_head, green.head_point.X += green.head_move.X);
                        Canvas.SetTop(green_head, green.head_point.Y += green.head_move.Y);

                        await Task.Delay(500);
                    }
                }
            }
            

            if(Math.Abs(Canvas.GetLeft(green_head) - Canvas.GetLeft(Apple)) < 25 && Math.Abs(Canvas.GetTop(green_head) - Canvas.GetTop(Apple)) < 25)
            {
                Canvas.SetLeft(Apple, r.Next(0, 30) * 25);
                Canvas.SetTop(Apple, r.Next(0, 30) * 25);

                green.size_up();
            }
            if (Math.Abs(Canvas.GetLeft(blue_head) - Canvas.GetLeft(Apple)) < 25 && Math.Abs(Canvas.GetTop(blue_head) - Canvas.GetTop(Apple)) < 25)
            {
                Canvas.SetLeft(Apple, r.Next(0, 30) * 25);
                Canvas.SetTop(Apple, r.Next(0, 30) * 25);

                blue.size_up();
            }



        }

       
    }
}
