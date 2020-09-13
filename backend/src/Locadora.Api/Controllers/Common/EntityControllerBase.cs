using FluentValidation.Results;

using Locadora.Application.Features.Common;
using Locadora.Domain.Features.Common;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Api.Controllers.Genres
{
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
            ValidationResult validationResult = entity.Validate();

            if (!validationResult.IsValid)
                return UnprocessableEntity(validationResult.ToString());

            return Ok(await serviceBase.Add(entity));
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            return Ok(await serviceBase.GetAll());
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            return Ok(await serviceBase.GetById(id));
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
