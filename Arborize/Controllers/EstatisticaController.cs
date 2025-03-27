// using Microsoft.AspNetCore.Mvc;
// using Arborize.Data;
// using System.Threading.Tasks;
// using System.Linq;
// using Arborize.Models;

// // namespace Arborize.Controllers
// // {
// //     public class EstatisticaController : Controller
// //     {
// //         private readonly AppDbContext _context;

// //         public EstatisticaController(AppDbContext context)
// //         {
// //             _context = context;
// //         }

//         public async Task<IActionResult> Index(int usuarioId)
//         {
//             // Chama os métodos agora com o parâmetro usuarioId
//             var dadosPlantio = await _context.ObterDadosPlantioPorTempoAsync(usuarioId);
//             var totalEspecies = await _context.ObterTotalEspeciesAsync(usuarioId);

//             var dadosGrafico = new
//             {
//                 datas = dadosPlantio.Select(dp => dp.DataPlantio.ToShortDateString()).ToArray(),
//                 totais = dadosPlantio.Select(dp => dp.Quantidade).ToArray()
//             };

//             // Passa os dados para a view
//             return View(new { dadosGrafico, totalEspecies });
//         }
//     }
// }
