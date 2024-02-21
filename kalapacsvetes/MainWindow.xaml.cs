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

namespace kalapacsvetes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region Adatok beolvasása
            List<Versenyző> versenyzők = new();
            foreach (var sor in File.ReadAllLines("Source\\Selejtezo2012.txt").Skip(1))
            {
                versenyzők.Add(new Versenyző(sor));
            }
            #endregion

            
            versenyzők.Count();


            versenyzők.Count(x => x.D1 > 78 || x.D2 > 78);
            Console.WriteLine(versenyzők.Count(x => x.D1 > 78 || x.D2 > 78));


            Versenyző? legjobb = versenyzők.MaxBy(x => x.Eredmény());
            Console.WriteLine(legjobb.Nemzet);
            Console.WriteLine(legjobb.Név);


            File.WriteAllLines("Dontos2012.txt", versenyzők.OrderByDescending(x => x.Eredmény()).Take(12).Select(ob => ob.ToString()));
        }
    }
}
