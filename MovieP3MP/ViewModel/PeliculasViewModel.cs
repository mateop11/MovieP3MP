
using System.Collections.ObjectModel;

using System.Net.Http.Json;

using MovieP3MP.Modelos;

using MovieP3MP.Servicios;

namespace MovieP3MP.ViewModels;

public class PeliculasViewModel : BaseViewModel
{
    private readonly BaseDeDatosServicio _baseDeDatosServicio;
    private string _consultaBusqueda;
    public string ConsultaBusqueda
    {
        get => _consultaBusqueda;
        set => SetProperty(ref _consultaBusqueda, value);
    }

    public ObservableCollection<Pelicula> Peliculas { get; } = new();

    public Command BuscarPeliculaCommand { get; }
    public Command LimpiarBusquedaCommand { get; }

    public PeliculasViewModel(BaseDeDatosServicio baseDeDatosServicio)
    {
        _baseDeDatosServicio = baseDeDatosServicio;

        BuscarPeliculaCommand = new Command(async () => await BuscarPeliculaAsync());
        LimpiarBusquedaCommand = new Command(() => ConsultaBusqueda = string.Empty);

        CargarPeliculas();
    }

    private async Task BuscarPeliculaAsync()
    {
        if (string.IsNullOrWhiteSpace(ConsultaBusqueda)) return;

        using var cliente = new HttpClient();
        var respuesta = await cliente.GetFromJsonAsync<List<Pelicula>>($"https://freetestapi.com/api/v1/movies?search={ConsultaBusqueda}");

        if (respuesta != null && respuesta.Any())
        {
            var pelicula = respuesta.First();
            pelicula.MPillajo = "Mateo Pillajo";

            await _baseDeDatosServicio.AgregarPeliculaAsync(pelicula);
            CargarPeliculas();
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Error", "No se encontró ninguna película.", "Aceptar");
        }
    }

    private async void CargarPeliculas()
    {
        Peliculas.Clear();
        var peliculas = await _baseDeDatosServicio.ObtenerPeliculasAsync();
        foreach (var pelicula in peliculas)
        {
            Peliculas.Add(pelicula);
        }
    }
}
