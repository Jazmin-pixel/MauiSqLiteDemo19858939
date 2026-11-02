using System.ComponentModel.Design;

namespace MauiSqLiteDemo19858939
{
    public partial class MainPage : ContentPage
    {
        private readonly localservidor _localservidor;
        private int _editClienteId;

        public MainPage()
        {
            InitializeComponent();
            _localservidor = new localservidor();
            Task.Run(async () => ListView.ItemsSource = await _localservidor.GetClientesAsync());
        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            if (_editClienteId == 0)
            {
                // agregar cliente
                await _localservidor.Create(new Cliente
                {
                    NombreCliente = nombreEntryField.Text,
                    Movil = movilEntryField.Text,
                    Email = emailEntryField.Text
                });
            }
            else
            {
                // editar cliente
                await _localservidor.Update(new Cliente
                {
                    Id = _editClienteId,
                    NombreCliente = nombreEntryField.Text,
                    Movil = movilEntryField.Text,
                    Email = emailEntryField.Text
                });
                _editClienteId = 0;
            }

            nombreEntryField.Text = string.Empty;
            emailEntryField.Text = string.Empty;
            movilEntryField.Text = string.Empty;

            ListView.ItemsSource = await _localservidor.GetClientesAsync();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var clientes = (Cliente)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

            switch(action)
            {
                case "Edit":
                    _editClienteId = clientes.Id;
                    nombreEntryField.Text = clientes.NombreCliente;
                    emailEntryField.Text = clientes.Email;
                    movilEntryField.Text = clientes.Movil;
                    break;

                case "Delete":
                    await _localservidor.Delete(clientes);
                    ListView.ItemsSource = await _localservidor.GetClientesAsync();
                    break;
            }
        }
    }
}
