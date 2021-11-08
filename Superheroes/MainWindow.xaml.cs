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

namespace Superheroes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Superheroe> listaSuperHeroes;
        public MainWindow()
        {
            InitializeComponent();
            listaSuperHeroes = Superheroe.GetSamples();
            dockPanelPrincipal.DataContext = listaSuperHeroes.FirstOrDefault();
            textBlockNumeroActual.Text = "1";
            textBlockTotalHeros.Text = listaSuperHeroes.Count.ToString();
           
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int heroActual = Int32.Parse(textBlockNumeroActual.Text);

            if (heroActual < listaSuperHeroes.Count)
            {
                dockPanelPrincipal.DataContext = listaSuperHeroes[heroActual];

                textBlockNumeroActual.Text = (heroActual + 1).ToString();
            }
            
        }

        private void imageAtras_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int heroActual = Int32.Parse(textBlockNumeroActual.Text);
            if (heroActual > 1)
            {
                dockPanelPrincipal.DataContext = listaSuperHeroes[heroActual - 2];
                textBlockNumeroActual.Text = (heroActual - 1).ToString();
            }
        }
    }
}
