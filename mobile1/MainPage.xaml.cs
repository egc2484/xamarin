using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using mobile1.Modelos;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace mobile1
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object> { 1, "2", true,false };
        public Command AgregarComando { get; set; } 


        public MainPage()
        {
            AgregarComando = new Command(async () => await cargarItems());
            InitializeComponent();

            // ButtonAgregar.Clicked += (sender, arg) => DisplayAlert("Titulo", "Hola", "Cerrar");

            ButtonAgregar.Clicked +=  ButtonAgregar_Click;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await cargarItems();
        }

        private async void ButtonAgregar_Click(object sender, EventArgs arg)
        {
           await cargarItems();
        }

        private async Task cargarItems()
        {
            if(Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Advertencia","No Hay Internet","Cerrar");
            }

            IsBusy = true;

            //await Task.Delay(2500);

            //Items.Add($"Elemento #{Items.Count}");
            Items.Clear();

            var productos = await cargarProductos();

            foreach (var item in productos)
            {
                Items.Add(item);
            }



            //await DisplayAlert("Titulo", "Hola!", "Cerrar");
        }

        private async Task<Producto[]>  cargarProductos()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(App.webserviceurl);
            var json = await client.GetStringAsync("api/products");

            Console.WriteLine(json);

            var resultado = JsonConvert.DeserializeObject<Producto[]>(json);

            return resultado;
        }

}
}
