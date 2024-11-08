using CommunityToolkit.Mvvm.Messaging;
using RotiNet.Class;
using RotiNet.View;
using RotiNet.View.Clientes;

namespace RotiNet
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            //código para preparar la recepción de mensajes y la llamada al método RecibirMensaje
            WeakReferenceMessenger.Default.Register<MyMessage>(this, (r, m) =>
            {
                AlRecibirMensaje(m);
            });
        }

        private async void AlRecibirMensaje(MyMessage m)
        {
            if (m.Value == "AbrirAddEditClienteView")
            {
                await Navigation.PushAsync(new AddEditClienteView(m.Cliente));
            }
            if (m.Value == "AbrirClientes")
            {
                await Navigation.PushAsync(new ClienteView());
            }
            if (m.Value == "VolverAClientes")
            {
                await Navigation.PopAsync();
            }
        }



        private async  void BtnClientes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClienteView());
        }
    }

}
