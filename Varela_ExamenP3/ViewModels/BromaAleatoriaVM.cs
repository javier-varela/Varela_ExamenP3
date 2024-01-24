using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Varela_ExamenP3.Models;

namespace Varela_ExamenP3.ViewModels
{
    public class BromaAleatoriaVM : ObservableObject
    {
        public JokesDB _db { get; set; }
        public Joke JV_Chiste { get; set; }
        public bool JVActivityIndicator
        {
            get => jVActivityIndicator; set
            {
                SetProperty(ref jVActivityIndicator, value);
            }
        }
        public bool ShowButton
        {
            get => showButton; set
            {
                SetProperty(ref showButton, value);
            }
        }
        HttpClient _client;
        JsonSerializerOptions _jsonSerializerOptions;
        string baseURl = "https://api.chucknorris.io/jokes/random";
        private bool showButton;
        private bool jVActivityIndicator;

        public BromaAleatoriaVM()
        {
            _db = new JokesDB();
            ShowButton = false;
            JVActivityIndicator = false;
            _client = new HttpClient();
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            JV_Chiste = new Joke();
        }

        public ICommand JV_GetRandomJoke =>
            new Command(JV_GetRandom);

        public ICommand JV_SaveJoke =>
            new Command(async () =>
            {
                await _db.SaveItemAsync(JV_Chiste);
            });


        private async void JV_GetRandom()
        {
            JVActivityIndicator = true;
            var response = await _client.GetAsync(baseURl);
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var body = await JsonSerializer.DeserializeAsync<Joke>(responseStream, _jsonSerializerOptions);
                    JV_Chiste.value = body.value;
                }
            }
            JVActivityIndicator = false;
            ShowButton = true;
        }
    }
}
