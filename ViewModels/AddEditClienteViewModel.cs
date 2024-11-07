using RotiNet.Modelos;
using RotiNet.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using RotiNet.Class;

namespace RotiNet.ViewModels
{
    public class AddEditClienteViewModel : ObservableObject
    {
        private readonly GenericService<Cliente> clienteService = new GenericService<Cliente>();
        private Cliente cliente;

        public Cliente Cliente
        {
            get => cliente;
            set
            {
                cliente = value;
                OnPropertyChanged();
            }
        }

        public AddEditClienteViewModel()
        {
            Cliente = cliente ?? new Cliente();
            GuardarCommand = new AsyncRelayCommand(Guardar);
            CancelarCommand = new RelayCommand(Cancelar);
        }

        public IAsyncRelayCommand GuardarCommand { get; }
        public IRelayCommand CancelarCommand { get; }

        private async Task Guardar()
        {
            if (Cliente.Id == 0)
            {
                await clienteService.AddAsync(Cliente);
            }
            else
            {
                await clienteService.UpdateAsync(Cliente);
            }
            WeakReferenceMessenger.Default.Send(new MyMessage("VolverAClientes"));
        }

        private void Cancelar()
        {
            WeakReferenceMessenger.Default.Send(new MyMessage("VolverAClientes"));
        }
    }
}
