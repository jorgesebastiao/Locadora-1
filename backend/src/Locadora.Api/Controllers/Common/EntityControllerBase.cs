using FluentValidation.Results;

using Locadora.Application.Features.Common;
using Locadora.Domain.Features.Common;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Api.Controllers.Genres
{

    /// <summary>
    /// Classe base para os controladores da aplicação
    /// Todas as entidades seguem um padrão, essa classe serve para não haver repetição da mesma lógica em todos os controladores
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EntityControllerBase<T> : ControllerBase where T : Entity
    {
        private readonly IServiceBase<T> serviceBase;

        protected EntityControllerBase(IServiceBase<T> serviceBase)
        {
            this.serviceBase = serviceBase;
        }

        [HttpPost]
        public async Task<IActionResult> Add(T entity)
        {
            //Realizando a validação para não prosseguir caso a entidade esteja com valores inválidos
            ValidationResult validationResult = entity.Validate();

            if (!validationResult.IsValid)
                return UnprocessableEntity(validationResult.ToString()); // Retornar erro code 422 para entidade invalida

            return Ok(await serviceBase.Add(entity)); // Retornar erro code 200 com o id da entidade inserida no banco
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            return Ok(await serviceBase.GetAll());
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            T foundedEntity = await serviceBase.GetById(id);

            if (foundedEntity == null)
                return NotFound();

            return Ok(foundedEntity);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(T entity)
        {
            ValidationResult validationResult = entity.Validate();

            if (!validationResult.IsValid)
                return UnprocessableEntity(validationResult.ToString());

            return Ok(await serviceBase.Update(entity));
        }

        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await serviceBase.Delete(id);

            return Accepted();
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete([FromBody]IEnumerable<int> ids)
        {
            await serviceBase.Delete(ids);

            return Accepted();
        }
    }
}
