using SQLite;
using MovieP3MP.Modelos;

namespace MovieP3MP.Servicios;

public class BaseDeDatosServicio
{
    private readonly SQLiteAsyncConnection _baseDeDatos;

    public BaseDeDatosServicio(string rutaBD)
    {
        _baseDeDatos = new SQLiteAsyncConnection(rutaBD);
        _baseDeDatos.CreateTableAsync<Pelicula>().Wait();
    }

    public Task<int> AgregarPeliculaAsync(Pelicula pelicula)
    {
        return _baseDeDatos.InsertAsync(pelicula);
    }

    public Task<List<Pelicula>> ObtenerPeliculasAsync()
    {
        return _baseDeDatos.Table<Pelicula>().ToListAsync();
    }

    public Task<int> EliminarTodasLasPeliculasAsync()
    {
        return _baseDeDatos.DeleteAllAsync<Pelicula>();
    }
}
