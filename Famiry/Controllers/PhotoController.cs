using Famiry.Data;
using Famiry.Service;
using FamiryEntityLibrary.Transfer.Photo;
using Microsoft.AspNetCore.Mvc;

namespace Famiry.Controllers
{
    [Route("api/photo")]
    [ApiController]
    public class PhotoController(PhotoService dataEntityService) : ControllerBase
    {
        /// <summary>
        ///     Сервис моделей.
        /// </summary>
        private PhotoService DataEntityService { get; } = dataEntityService;

        /// <summary>
        ///     Получить список растений.
        ///     Если идентификаторы не указаны, возвращается список со всеми растениями.
        ///     Иначе возвращается список с указанными растениями, либо пустой список.
        /// </summary>
        /// <param name="ids">Список идентификаторов.</param>
        /// <returns>Результат операции со списком растений.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoDTO>>> Get([FromQuery] string userId, [FromQuery] List<int>? ids)
        {
            var Photos = (await DataEntityService.Get(((DataContext)DataEntityService.DataContext).Photos, ids)).Select(x => x.ToDTO()).ToList();
            return Ok(Photos);
        }

        /// <summary>
        ///     Сохранить растения.
        /// </summary>
        /// <param name="entities">Список растений.</param>
        /// <returns>Результат операции.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<RequestPhotoDTO> entities)
        {
            var status = await DataEntityService.Set(((DataContext)DataEntityService.DataContext).Photos, entities.Select(x => x.ToEntity()).ToList());

            if (!status)
            {
                return BadRequest("No Photos were saved!");
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
            var status = await DataEntityService.Remove(((DataContext)DataEntityService.DataContext).Photos, ids);

            if (!status)
            {
                return BadRequest("No Photos were deleted!");
            }

            return Ok();
        }
    }
}