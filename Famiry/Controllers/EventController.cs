using Famiry.Data;
using Famiry.Service;
using Microsoft.AspNetCore.Mvc;

namespace Famiry.Controllers
{
    [Route("api/Event")]
    [ApiController]
    public class EventController(EventService dataEntityService) : ControllerBase
    {
        /// <summary>
        ///     Сервис моделей.
        /// </summary>
        private EventService DataEntityService { get; } = dataEntityService;

        /// <summary>
        ///     Получить список растений.
        ///     Если идентификаторы не указаны, возвращается список со всеми растениями.
        ///     Иначе возвращается список с указанными растениями, либо пустой список.
        /// </summary>
        /// <param name="ids">Список идентификаторов.</param>
        /// <returns>Результат операции со списком растений.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDTO>>> Get([FromQuery] string userId, [FromQuery] List<int>? ids)
        {
            var Events = (await DataEntityService.Get(((DataContext)DataEntityService.DataContext).Events, userId, ids)).Select(x => x.ToDTO()).ToList();
            return Ok(Events);
        }

        /// <summary>
        ///     Сохранить растения.
        /// </summary>
        /// <param name="entities">Список растений.</param>
        /// <returns>Результат операции.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<RequestEventDTO> entities)
        {
            var status = await DataEntityService.Set(((DataContext)DataEntityService.DataContext).Events, entities.Select(x => x.ToEntity()).ToList());

            if (!status)
            {
                return BadRequest("No Events were saved!");
            }

            return Ok();
        }

        /// <summary>
        ///     Удалить растения.
        /// </summary>
        /// <param name="ids">Список идентификаторов.</param>
        /// <returns>Результат операции.</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var status = await DataEntityService.Remove(((DataContext)DataEntityService.DataContext).Events, ids);

            if (!status)
            {
                return BadRequest("No Events were deleted!");
            }

            return Ok();
        }
    }
}
}
