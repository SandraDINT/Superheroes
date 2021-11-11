using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Superheroes
{
    class MainWindowVM : INotifyPropertyChanged
    {
        private Superheroe _superheroeActual;

        public Superheroe SuperheroeActual
        {
            get { return _superheroeActual; }
            set
            {
                _superheroeActual = value;
                NotifyPropertyChanged("SuperheroeActual");
            }
        }

        private int _contadorHeroeActual;

        public int ContadorHeroeActual
        {
            get { return _contadorHeroeActual; }
            set { _contadorHeroeActual = value;
                NotifyPropertyChanged("ContadorHeroeActual");
            }
        }

        private int _totalHeroes;

        public int TotalHeroes
        {
            get { return _totalHeroes; }
            set { _totalHeroes = value;
                NotifyPropertyChanged("TotalHeroes");
            }
        }

        private List<Superheroe> lista = Superheroe.GetSamples();

        public MainWindowVM()
        {
            
            SuperheroeActual = lista.FirstOrDefault();
            ContadorHeroeActual = 1;
            TotalHeroes = lista.Count;
        }

        public void Avanzar()
        {
            if(ContadorHeroeActual < TotalHeroes)
            {
                ContadorHeroeActual++;
                SuperheroeActual = lista[ContadorHeroeActual - 1];
            }
            
        }
        public void Retroceder()
        {
            if (ContadorHeroeActual > 1)
            {
                ContadorHeroeActual--;
                SuperheroeActual = lista[ContadorHeroeActual - 1];
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
