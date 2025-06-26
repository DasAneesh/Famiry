using Famiry.Data;
using Famiry.Service;
using FamiryEntityLibrary.Transfer.User;
using Microsoft.AspNetCore.Mvc;

namespace Famiry.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController(UserService dataEntityService) : ControllerBase
    {
        /// <summary>
        ///     Сервис моделей.
        /// </summary>
        private UserService DataEntityService { get; } = dataEntityService;

        /// <summary>
        ///     Получить список растений.
        ///     Если идентификаторы не указаны, возвращается список со всеми растениями.
        ///     Иначе возвращается список с указанными растениями, либо пустой список.
        /// </summary>
        /// <param name="ids">Список идентификаторов.</param>
        /// <returns>Результат операции со списком растений.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get([FromQuery] string userId, [FromQuery] List<int>? ids)
        {
            var Users = (await DataEntityService.Get(((DataContext)DataEntityService.DataContext).Users, ids)).Select(x => x.ToDTO()).ToList();
            return Ok(Users);
        }

        /// <summary>
        ///     Сохранить растения.
        /// </summary>
        /// <param name="entities">Список растений.</param>
        /// <returns>Результат операции.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<RequestUserDTO> entities)
        {
            var status = await DataEntityService.Set(((DataContext)DataEntityService.DataContext).Users, entities.Select(x => x.ToEntity()).ToList());

            if (!status)
            {
                return BadRequest("No Users were saved!");
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
            var status = await DataEntityService.Remove(((DataContext)DataEntityService.DataContext).Users, ids);

            if (!status)
            {
                return BadRequest("No Users were deleted!");
            }

            return Ok();
        }
    }
}