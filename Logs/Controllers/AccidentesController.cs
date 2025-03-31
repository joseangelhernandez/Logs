using log4net;
using Logs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Logs.Controllers
{
    public class AccidentesController : Controller
    {
        private readonly AccidentesContext _context;
        private readonly ILog _logger;

        public AccidentesController(AccidentesContext context, ILog log)
        {
            _context = context;
            _logger = log;
        }

        // GET: Accidentes
        public async Task<IActionResult> Index()
        {
            _logger.Info("Consulta de lista de Accidentes.");
            return View(await _context.TblAccidentes.ToListAsync());
        }

        // GET: Accidentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                _logger.Error("No se recibió el id del Accidente.");
                return NotFound();
            }

            var tblAccidente = await _context.TblAccidentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAccidente == null)
            {
                _logger.Error($"No se encontró el Accidente con el id: {id}.");
                return NotFound();
            }

            _logger.Info($"Consulta de detalle de Accidente con el id: {id}.");
            return View(tblAccidente);
        }

        // GET: Accidentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accidentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,CantidadHeridos,CantidadFallecidos,CantidadVehiculos,FechaAccidente,EstadoRegistro,Geolocalizacion,Usuario,Ciudad,Pais")] TblAccidente tblAccidente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAccidente);
                await _context.SaveChangesAsync();

                _logger.Info($"Se creó un nuevo Accidente con el id: {tblAccidente.Id}, Descripción: {tblAccidente.Descripcion}, " +
                             $"Cantidad de Heridos: {tblAccidente.CantidadHeridos}, Cantidad de Fallecidos: {tblAccidente.CantidadFallecidos}, " +
                             $"Cantidad de Vehículos: {tblAccidente.CantidadVehiculos}, Fecha: {tblAccidente.FechaAccidente}, " +
                             $"Estado: {tblAccidente.EstadoRegistro}, Geolocalización: {tblAccidente.Geolocalizacion}, " +
                             $"Usuario: {tblAccidente.Usuario}, Ciudad: {tblAccidente.Ciudad}, País: {tblAccidente.Pais}.");

                return RedirectToAction(nameof(Index));
            }
            return View(tblAccidente);
        }

        // GET: Accidentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                _logger.Error("No se recibió el id del Accidente.");
                return NotFound();
            }

            var tblAccidente = await _context.TblAccidentes.FindAsync(id);
            if (tblAccidente == null)
            {
                _logger.Error($"No se encontró el Accidente con el id: {id}.");
                return NotFound();
            }

            _logger.Info($"Consulta de detalle de Accidente con el id: {id}. Para Editarlo.");
            return View(tblAccidente);
        }

        // POST: Accidentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,CantidadHeridos,CantidadFallecidos,CantidadVehiculos,FechaAccidente,EstadoRegistro,Geolocalizacion,Usuario,Ciudad,Pais")] TblAccidente tblAccidente)
        {
            if (id != tblAccidente.Id)
            {
                _logger.Error($"El id del Accidente: {id}, no coincide con el id del Accidente: {tblAccidente.Id}.");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAccidente);
                    await _context.SaveChangesAsync();

                    _logger.Info($"Se Editó el accidente con el id: {tblAccidente.Id}, con la siguiente nueva información, Descripción: {tblAccidente.Descripcion}, " +
                                 $"Cantidad de Heridos: {tblAccidente.CantidadHeridos}, Cantidad de Fallecidos: {tblAccidente.CantidadFallecidos}, " +
                                 $"Cantidad de Vehículos: {tblAccidente.CantidadVehiculos}, Fecha: {tblAccidente.FechaAccidente}, " +
                                 $"Estado: {tblAccidente.EstadoRegistro}, Geolocalización: {tblAccidente.Geolocalizacion}, " +
                                 $"Usuario: {tblAccidente.Usuario}, Ciudad: {tblAccidente.Ciudad}, País: {tblAccidente.Pais}.");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!TblAccidenteExists(tblAccidente.Id))
                    {
                        _logger.Error($"No se encontró el Accidente con el id: {tblAccidente.Id} en la base de datos.");
                        return NotFound();
                    }
                    else
                    {
                        _logger.Error($"Error al Editar el Accidente con el id: {tblAccidente.Id}. Error: {ex.Message}");
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblAccidente);
        }

        // GET: Accidentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                _logger.Error("No se recibió el id del Accidente.");
                return NotFound();
            }

            var tblAccidente = await _context.TblAccidentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAccidente == null)
            {
                _logger.Error($"No se encontró el Accidente con el id: {id}.");
                return NotFound();
            }

            _logger.Info($"Consulta de detalle de Accidente con el id: {id}. Para Eliminarlo.");
            return View(tblAccidente);
        }

        // POST: Accidentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAccidente = await _context.TblAccidentes.FindAsync(id);
            if (tblAccidente != null)
            {
                _context.TblAccidentes.Remove(tblAccidente);
                await _context.SaveChangesAsync();

                _logger.Info($"Se eliminó el Accidente con el ID: {tblAccidente.Id}, " +
                             $"Descripción: {tblAccidente.Descripcion}, " +
                             $"Cantidad de Heridos: {tblAccidente.CantidadHeridos}, " +
                             $"Cantidad de Fallecidos: {tblAccidente.CantidadFallecidos}, " +
                             $"Cantidad de Vehículos: {tblAccidente.CantidadVehiculos}, " +
                             $"Fecha: {tblAccidente.FechaAccidente}, " +
                             $"Estado: {tblAccidente.EstadoRegistro}, " +
                             $"Geolocalización: {tblAccidente.Geolocalizacion}, " +
                             $"Usuario: {tblAccidente.Usuario}, " +
                             $"Ciudad: {tblAccidente.Ciudad}, " +
                             $"País: {tblAccidente.Pais}.");
            }
            else
            {
                _logger.Warn($"Intento de eliminación fallido. No se encontró un Accidente con el ID: {id}.");
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TblAccidenteExists(int id)
        {
            return _context.TblAccidentes.Any(e => e.Id == id);
        }
    }
}
