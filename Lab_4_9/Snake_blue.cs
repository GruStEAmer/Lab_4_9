using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace Lab_4_9
{
    internal class Snake_blue
    {
        private Canvas _canvas = new Canvas();
        private static int SZ = 25;

        public Point head_point = new Point(0, 0);
        public Point head_move = new Point(0, 0);
        public TextBox head = new TextBox
        {
            Width = SZ,
            Height = SZ,
            Background = new SolidColorBrush(Colors.Blue),
            IsReadOnly = true,
        };


        private List<TextBox> tbsnake = new List<TextBox>();
        private Point pnt = new Point();


        public void getCanvas(Canvas canvas)
        {
            _canvas = canvas;
        }


        public void Move(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    head_move.Y = -25;
                    head_move.X = 0;
                    return;
                case Key.Down:
                    head_move.Y = 25;
                    head_move.X = 0;
                    return;
                case Key.Right:
                    head_move.X = 25;
                    head_move.Y = 0;
                    return;
                case Key.Left:
                    head_move.X = -25;
                    head_move.Y = 0;
                    return;
            }
            head_move.X = 0; head_move.Y = 0;
        }

        public void showSnake()
        {
            for (int i = tbsnake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    Canvas.SetLeft(tbsnake[i], head_point.X);
                    Canvas.SetTop(tbsnake[i], head_point.Y);
                }
                else
                {
                    Canvas.SetLeft(tbsnake[i], Canvas.GetLeft(tbsnake[i - 1]));
                    Canvas.SetTop(tbsnake[i], Canvas.GetTop(tbsnake[i - 1]));


                }
            }
        }

        public void size_up()
        {

            TextBox new_tb = new TextBox
            {
                Background = new SolidColorBrush(Colors.Blue),
                Width = SZ,
                Height = SZ,
                IsReadOnly = true,
            };

            if (tbsnake.Count > 0)
            {
                Canvas.SetLeft(new_tb, Canvas.GetLeft(tbsnake.Last()));
                Canvas.SetTop(new_tb, Canvas.GetTop(tbsnake.Last()) + 25);
            }
            else
            {
                Canvas.SetLeft(new_tb, Canvas.GetLeft(head));
                Canvas.SetTop(new_tb, Canvas.GetTop(head) + 25);

            }
            tbsnake.Add(new_tb);
            _canvas.Children.Add(new_tb);
        }
    }
}
