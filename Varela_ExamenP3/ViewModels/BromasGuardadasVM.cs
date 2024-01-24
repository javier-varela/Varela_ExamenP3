using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varela_ExamenP3.Models;

namespace Varela_ExamenP3.ViewModels
{
    public class BromasGuardadasVM : ObservableObject
    {
        private List<Joke> jVBromasGuardadas;

        public JokesDB _db { get; set; }
        public List<Joke> JVBromasGuardadas
        {
            get => jVBromasGuardadas; set
            {
                SetProperty(ref jVBromasGuardadas, value);
            }
        }
        public BromasGuardadasVM()
        {
            _db = new JokesDB();
            CargarBromas();
        }

        public async void CargarBromas()
        {
            JVBromasGuardadas =await _db.GetItemsAsync();
        }
    }
}
