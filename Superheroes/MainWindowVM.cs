using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Superheroes
{
    class MainWindowVM : ObservableObject
    {
        
        private List<Superheroe> lista;
        private ListaSuperheroesService servicioHeroes;

        public RelayCommand SiguienteCommand { get; }
        public RelayCommand RetrocederCommand { get; }

        public MainWindowVM()
        {
            servicioHeroes = new ListaSuperheroesService();
            lista = servicioHeroes.GetSamples();
            SuperheroeActual = lista.FirstOrDefault();
            ContadorHeroeActual = 1;
            TotalHeroes = lista.Count;
            SiguienteCommand = new RelayCommand(Avanzar);
            RetrocederCommand = new RelayCommand(Retroceder);
        }

        private Superheroe _superheroeActual;
        public Superheroe SuperheroeActual
        {
            get { return _superheroeActual; }
            set
            {
                SetProperty(ref _superheroeActual, value);
            }
        }

        private int _contadorHeroeActual;

        public int ContadorHeroeActual
        {
            get { return _contadorHeroeActual; }
            set {
                SetProperty(ref _contadorHeroeActual, value);
            }
        }

        private int _totalHeroes;

        public int TotalHeroes
        {
            get { return _totalHeroes; }
            set {
                SetProperty(ref _totalHeroes, value);
            }
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
    }
}
