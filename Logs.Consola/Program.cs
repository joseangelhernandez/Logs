using log4net;
using log4net.Config;
using Logs.Models;

public class Program
{

    private static readonly ILog log = LogManager.GetLogger(typeof(string));

    static void Main(string[] args)
    {
        try
        {
            TblAccidente accidente = new TblAccidente();
            BasicConfigurator.Configure();

            Console.WriteLine("Registra el accidente:");

            Console.WriteLine("Descripción:");
            accidente.Descripcion = Console.ReadLine();
            Console.WriteLine("Cantidad de Heridos:");
            accidente.CantidadHeridos = int.Parse(Console.ReadLine());
            Console.WriteLine("Cantidad de Fallecidos:");
            accidente.CantidadFallecidos = int.Parse(Console.ReadLine());
            Console.WriteLine("Cantidad de Vehículos:");
            accidente.CantidadVehiculos = int.Parse(Console.ReadLine());
            accidente.FechaAccidente = DateTime.Now;
            accidente.EstadoRegistro = 1;
            Console.WriteLine("Geolocalización:");
            accidente.Geolocalizacion = Console.ReadLine();
            Console.WriteLine("Usuario:");
            accidente.Usuario = Console.ReadLine();
            Console.WriteLine("Ciudad:");
            accidente.Ciudad = Console.ReadLine();
            Console.WriteLine("País:");
            accidente.Pais = Console.ReadLine();

            log.Info($"Se creó un nuevo Accidente con la siguiente información, Descripción: {accidente.Descripcion}, " +
                     $"Cantidad de Heridos: {accidente.CantidadHeridos}, Cantidad de Fallecidos: {accidente.CantidadFallecidos}, " +
                     $"Cantidad de Vehículos: {accidente.CantidadVehiculos}, Fecha: {accidente.FechaAccidente}, " +
                     $"Estado: {accidente.EstadoRegistro}, Geolocalización: {accidente.Geolocalizacion}, " +
                     $"Usuario: {accidente.Usuario}, Ciudad: {accidente.Ciudad}, País: {accidente.Pais}.");

            log.Info("ACCIDENTE REGISTRADO CON ÉXITO.");
        }
        catch (Exception ex)
        {
            log.Error("Error al registrar el accidente.", ex);
        }
    }
}