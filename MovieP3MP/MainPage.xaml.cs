using MovieP3MP.ViewModels;
using MovieP3MP.Servicios;

namespace MovieP3MP;

public partial class MainPage : TabbedPage
{
    public MainPage()
    {
        InitializeComponent();

        var rutaBD = Path.Combine(FileSystem.AppDataDirectory, "mateopillajo.db3");
        var baseDeDatosServicio = new BaseDeDatosServicio(rutaBD);

        BindingContext = new PeliculasViewModel(baseDeDatosServicio);
    }
}
