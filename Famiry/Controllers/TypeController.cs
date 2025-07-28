using Famiry.Data;
using Famiry.Service;
using FamiryEntityLibrary.Transfer.Type;
using Microsoft.AspNetCore.Mvc;

namespace Famiry.Controllers
{
    [Route("api/type")]
    [ApiController]
    public class TypeController(TypeService dataEntityService) : ControllerBase
    {
        /// <summary>
        ///     Сервис моделей.
        /// </summary>
        private TypeService DataEntityService { get; } = dataEntityService;

        /// <summary>
        ///     Получить список растений.
        ///     Если идентификаторы не указаны, возвращается список со всеми растениями.
        ///     Иначе возвращается список с указанными растениями, либо пустой список.
        /// </summary>
        /// <param name="ids">Список идентификаторов.</param>
        /// <returns>Результат операции со списком растений.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeDTO>>> Get([FromQuery] string userId, [FromQuery] List<int>? ids)
        {
            var Types = (await DataEntityService.Get(((DataContext)DataEntityService.DataContext).Types, ids)).Select(x => x.ToDTO()).ToList();
            return Ok(Types);
        }

        /// <summary>
        ///     Сохранить растения.
        /// </summary>
        /// <param name="entities">Список растений.</param>
        /// <returns>Результат операции.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<RequestTypeDTO> entities)
        {
            var status = await DataEntityService.Set(((DataContext)DataEntityService.DataContext).Types, entities.Select(x => x.ToEntity()).ToList());

            if (!status)
            {
                return BadRequest("No Types were saved!");
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
            var status = await DataEntityService.Remove(((DataContext)DataEntityService.DataContext).Types, ids);

            if (!status)
            {
                return BadRequest("No Types were deleted!");
            }

            return Ok();
        }
    }
}