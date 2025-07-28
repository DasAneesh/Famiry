using Famiry.Data;
using Famiry.Service;
using FamiryEntityLibrary.Transfer.Status;
using Microsoft.AspNetCore.Mvc;

namespace Famiry.Controllers
{
    [Route("api/status")]
    [ApiController]
    public class StatusController(StatusService dataEntityService) : ControllerBase
    {
        /// <summary>
        ///     Сервис моделей.
        /// </summary>
        private StatusService DataEntityService { get; } = dataEntityService;

        /// <summary>
        ///     Получить список растений.
        ///     Если идентификаторы не указаны, возвращается список со всеми растениями.
        ///     Иначе возвращается список с указанными растениями, либо пустой список.
        /// </summary>
        /// <param name="ids">Список идентификаторов.</param>
        /// <returns>Результат операции со списком растений.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusDTO>>> Get([FromQuery] string userId, [FromQuery] List<int>? ids)
        {
            var Statuss = (await DataEntityService.Get(((DataContext)DataEntityService.DataContext).Statuses, ids)).Select(x => x.ToDTO()).ToList();
            return Ok(Statuss);
        }

        /// <summary>
        ///     Сохранить растения.
        /// </summary>
        /// <param name="entities">Список растений.</param>
        /// <returns>Результат операции.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<RequestStatusDTO> entities)
        {
            var status = await DataEntityService.Set(((DataContext)DataEntityService.DataContext).Statuses, entities.Select(x => x.ToEntity()).ToList());

            if (!status)
            {
                return BadRequest("No Statuses were saved!");
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
            var status = await DataEntityService.Remove(((DataContext)DataEntityService.DataContext).Statuses, ids);

            if (!status)
            {
                return BadRequest("No Statuses were deleted!");
            }

            return Ok();
        }
    }
}