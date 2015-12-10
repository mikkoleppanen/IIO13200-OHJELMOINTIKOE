using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Tehtava1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Letter> letters;
        public MainWindow()
        {
            InitializeComponent();
            letters = new List<Letter>();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            letters.Clear();
            String input = textBox1.Text;

            Regex rgx = new Regex("[^a-zA-ZåÅöÖäÄ]");
            input = rgx.Replace(input, "");
            input = input.ToLower();

            foreach(Char item in input)
            {
                int index = letters.FindIndex(x => x.letter == item);
                if(index < 0)
                {
                    letters.Add(new Letter
                    {
                        letter = item,
                        count = 1
                    });
                }
                else
                {
                    letters[index].count++;
                }
            }

            //Tulostus
            label1.Content = "";
            foreach (Letter item in letters)
            {
                label1.Content += item.letter + " = " + item.count + Environment.NewLine;
            }
        }
    }
}
