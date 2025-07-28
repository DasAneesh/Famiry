using Famiry.Data;
using Famiry.Service;
using FamiryEntityLibrary.Transfer.Priority;
using Microsoft.AspNetCore.Mvc;

namespace Famiry.Controllers
{
    [Route("api/priority")]
    [ApiController]
    public class PriorityController(PriorityService dataEntityService) : ControllerBase
    {
        /// <summary>
        ///     Сервис моделей.
        /// </summary>
        private PriorityService DataEntityService { get; } = dataEntityService;

        /// <summary>
        ///     Получить список растений.
        ///     Если идентификаторы не указаны, возвращается список со всеми растениями.
        ///     Иначе возвращается список с указанными растениями, либо пустой список.
        /// </summary>
        /// <param name="ids">Список идентификаторов.</param>
        /// <returns>Результат операции со списком растений.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriorityDTO>>> Get([FromQuery] string userId, [FromQuery] List<int>? ids)
        {
            var Prioritys = (await DataEntityService.Get(((DataContext)DataEntityService.DataContext).Priorities, ids)).Select(x => x.ToDTO()).ToList();
            return Ok(Prioritys);
        }

        /// <summary>
        ///     Сохранить растения.
        /// </summary>
        /// <param name="entities">Список растений.</param>
        /// <returns>Результат операции.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<RequestPriorityDTO> entities)
        {
            var status = await DataEntityService.Set(((DataContext)DataEntityService.DataContext).Priorities, entities.Select(x => x.ToEntity()).ToList());

            if (!status)
            {
                return BadRequest("No Prioritys were saved!");
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
            var status = await DataEntityService.Remove(((DataContext)DataEntityService.DataContext).Priorities, ids);

            if (!status)
            {
                return BadRequest("No Prioritys were deleted!");
            }

            return Ok();
        }
    }
}