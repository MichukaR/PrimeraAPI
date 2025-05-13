using MiPrimeraAPIMichu.Modelos;

namespace MiPrimeraAPIMichu.Repositories;

public class BicicletasRepository
{
    public IEnumerable<Bicicleta> ObtenerListadoBicicletas()
    {
        
        List<Bicicleta> bicicletas = new List<Bicicleta>();
        Bicicleta Bicicleta1 = new Bicicleta
        {
            id = 1,
            marca = "Marca1",
            valor = 1000,
            material = "Aluminio",
            EsNueva = true
        };
        Bicicleta Bicicleta2 = new Bicicleta
        {
            id = 2,
            marca = "Marca2",
            valor = 100,
            material = "Papel",
            EsNueva = false
        };
        bicicletas.Add(Bicicleta1);
        bicicletas.Add(Bicicleta2);
        
        return bicicletas;
    }
    
    public Bicicleta ObtenerInformacionBicicleta(int id)
    {
        var bicicleta = ObtenerListadoBicicletas().First(x => x.id == id);
        return bicicleta;
    }

    public bool ActualizarBicicleta(Bicicleta bicicleta)
    {
        //Lógica para actualizar bicicleta
        return true;
    }

    public bool EliminarBicicleta(int id)
    {
        //Lógica para eliminar bicicleta
        return false;
    }
    public bool CrearBicicleta(Bicicleta bicicleta)
    {
        //Lógica para eliminar bicicleta
        return false;
    }
}