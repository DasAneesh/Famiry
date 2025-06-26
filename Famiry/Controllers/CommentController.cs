using Famiry.Data;
using Famiry.Service;
using FamiryEntityLibrary.Transfer.Comment;
using Microsoft.AspNetCore.Mvc;

namespace Famiry.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController(CommentService dataEntityService) : ControllerBase
    {
        /// <summary>
        ///     Сервис моделей.
        /// </summary>
        private CommentService DataEntityService { get; } = dataEntityService;

        /// <summary>
        ///     Получить список растений.
        ///     Если идентификаторы не указаны, возвращается список со всеми растениями.
        ///     Иначе возвращается список с указанными растениями, либо пустой список.
        /// </summary>
        /// <param name="ids">Список идентификаторов.</param>
        /// <returns>Результат операции со списком растений.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> Get([FromQuery] string userId, [FromQuery] List<int>? ids)
        {
            var Comments = (await DataEntityService.Get(((DataContext)DataEntityService.DataContext).Comments, ids)).Select(x => x.ToDTO()).ToList();
            return Ok(Comments);
        }

        /// <summary>
        ///     Сохранить растения.
        /// </summary>
        /// <param name="entities">Список растений.</param>
        /// <returns>Результат операции.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<RequestCommentDTO> entities)
        {
            var status = await DataEntityService.Set(((DataContext)DataEntityService.DataContext).Comments, entities.Select(x => x.ToEntity()).ToList());

            if (!status)
            {
                return BadRequest("No Comments were saved!");
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
            var status = await DataEntityService.Remove(((DataContext)DataEntityService.DataContext).Comments, ids);

            if (!status)
            {
                return BadRequest("No Comments were deleted!");
            }

            return Ok();
        }
    }
}