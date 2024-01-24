using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varela_ExamenP3.Models
{
    public class Joke : ObservableObject
    {
        private string value1;

        public List<string> categories { get; set; } = new();
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value
        {
            get => value1; set
            {
                SetProperty(ref value1, value);
            }
        }


    }
}
