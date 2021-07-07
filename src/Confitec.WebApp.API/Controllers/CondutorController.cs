using Confitec.Condutor.Application.Services;
using Confitec.Condutor.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.WebApp.API.Controllers
{
    [Route("v1/condutor")]
    public class CondutorController : ControllerBase
    {
        public readonly ICondutorAppService _condutorAppService;        

        public CondutorController(ICondutorAppService condutorAppService)
        {
            _condutorAppService = condutorAppService;            
        }

        [HttpGet]
        [Route("obterTodos")]
        public async Task<IEnumerable<CondutorViewModel>> Get()
        {
            var condutores = await _condutorAppService.ObterTodosCondutores();
            return condutores;
        }

        [HttpGet]
        [Route("obterPorPlaca/{placa}")]
        public async Task<IEnumerable<CondutorViewModel>> GetByCondutoresPlaca(string placa)
        {
            var condutores = await _condutorAppService.ObterCondutoresPorPlaca(placa);

            if (condutores == null) return (IEnumerable<CondutorViewModel>)NotFound("Não foi possível localizar os condutores para a placa informada");

            return condutores;
        }

        [HttpGet]
        [Route("obterPorId/{id:guid}")]
        public async Task<ActionResult<CondutorViewModel>> GetById(Guid id)
        {
            var condutor = await _condutorAppService.ObterCondutorPorId(id);

            if (condutor == null) return NotFound("Não foi possível localizar o condutor");

            return condutor;
        }

        [HttpGet]
        [Route("obterPorId/{cpf}")]
        public async Task<ActionResult<CondutorViewModel>> GetByCPF(string cpf)
        {
            var condutor = await _condutorAppService.ObterCondutorPorCPF(cpf);

            if (condutor == null) return NotFound("Não foi possível localizar o condutor");

            return condutor;
        }

        [HttpPost]
        [Route("adicionarCondutor")]
        public async Task<ActionResult<CondutorViewModel>> Post(CondutorViewModel condutorViewModel)
        {
            if (!ModelState.IsValid) return BadRequest("O formulário possui dados inválidos");

            var condutor = await _condutorAppService.ObterCondutorPorCPF(condutorViewModel.CPF);

            if (condutor != null)
            {
                if (condutor.CPF == condutorViewModel.CPF || condutor.CNH == condutorViewModel.CNH)
                {
                    return BadRequest("CPF ou CNH já cadastrados");
                }                     
            } 

            await _condutorAppService.AdicionarCondutor(condutorViewModel);

            return condutorViewModel;
        }

        [HttpPut]
        [Route("atualizarCondutor")]
        public async Task<ActionResult<CondutorViewModel>> Put(CondutorViewModel condutorViewModel)
        {
            if (!ModelState.IsValid) return BadRequest("O formulário possui dados inválidos");

            var condutor = await _condutorAppService.ObterCondutorPorId(condutorViewModel.Id);

            if (condutor == null)
            {
                return NotFound("Não foi possível localizar o condutor");
            }
            else
            {
                if (condutor.CPF == condutorViewModel.CPF) return BadRequest("CPF já cadastrado");
                if (condutor.CNH == condutorViewModel.CNH) return BadRequest("CNH já cadastrada");
            }

            await _condutorAppService.AtualizarCondutor(condutorViewModel);

            return condutorViewModel;
        }

        [HttpDelete]
        [Route("excluirCondutor/{id:guid}")]
        public async Task<ActionResult<CondutorViewModel>> Delete(Guid id)
        {
            var condutor = await _condutorAppService.ObterCondutorPorId(id);

            if (condutor == null) return NotFound("Não foi possível localizar o condutor");            

            await _condutorAppService.ExcluirCondutor(condutor);

            return condutor;
        }
    }
}
