using Confitec.Condutor.Application.Services;
using Confitec.Condutor.Application.ViewModels;
using Confitec.Core.Messages;
using Confitec.Veiculo.Application.Services;
using Confitec.WebApp.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.WebApp.API.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/condutor")]
    public class CondutorController : MainController
    {
        public readonly ICondutorAppService _condutorAppService;
        public readonly IVeiculoAppService _veiculoAppService;

        public CondutorController(ICondutorAppService condutorAppService, IVeiculoAppService veiculoAppService, INotificador notificador) : base(notificador)
        {
            _condutorAppService = condutorAppService;
            _veiculoAppService = veiculoAppService;
        }
        
        [HttpGet("obterTodos")]       
        public async Task<IEnumerable<CondutorViewModel>> ObterTodosCondutores()
        {
            var condutores = await _condutorAppService.ObterTodosCondutores();
            return condutores;
        }

        //[ClaimsAuthorize("Condutor", "Consultar")]
        [HttpGet("obterPorPlaca/{placa}")]        
        public async Task<ActionResult<IEnumerable<CondutorViewModel>>> ObterCondutoresPlaca(string placa)
        {  
            var veiculos = await _veiculoAppService.ObterVeiculosPorPlaca(placa);

            if (veiculos == null)
            {
                NotificarErro("Não foi possível localizar os condutores para a placa informada");
                return CustomResponse();
            }

            IList<CondutorViewModel> condutoresDaPlaca = new List<CondutorViewModel>();

            var condutores = await _condutorAppService.ObterTodosCondutores();

            foreach (var condutor in condutores)
            {
                foreach (var veiculo in veiculos)
                {
                    if (veiculo.CPFCondutor == condutor.CPF)
                    {
                        condutoresDaPlaca.Add(condutor);
                    }
                }
            }

            return CustomResponse(condutoresDaPlaca);            
        }

        //[ClaimsAuthorize("Condutor", "Consultar")]
        [HttpGet("obterPorId/{id:guid}")]        
        public async Task<ActionResult<CondutorViewModel>> ObterCondutorPorId(Guid id)
        {
            var condutor = await _condutorAppService.ObterCondutorPorId(id);

            if (condutor == null) CondutorNulo();            

            return CustomResponse(condutor);            
        }

        //[ClaimsAuthorize("Condutor", "Consultar")]
        [HttpGet("obterPorCpf/{cpf}")]        
        public async Task<ActionResult<CondutorViewModel>> ObterCondutorPorCPF(string cpf)
        {
            var condutor = await _condutorAppService.ObterCondutorPorCPF(cpf);

            if (condutor == null) CondutorNulo();

            return CustomResponse(condutor);            
        }

        //[ClaimsAuthorize("Condutor", "Adicionar")]
        [HttpPost("adicionarCondutor")]        
        public async Task<ActionResult<CondutorViewModel>> CadastrarCondutor(CondutorViewModel condutorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);           

            await _condutorAppService.AdicionarCondutor(condutorViewModel);
           
            return CustomResponse(condutorViewModel);
        }

        //[ClaimsAuthorize("Condutor", "Atualizar")]
        [HttpPut("atualizarCondutor/{id:guid}")]        
        public async Task<ActionResult<CondutorViewModel>> AtualizarCondutor(Guid id, CondutorViewModel condutorViewModel)
        {
            if (id != condutorViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(condutorViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);            

            await _condutorAppService.AtualizarCondutor(condutorViewModel);

            return CustomResponse(condutorViewModel);
        }

        //[ClaimsAuthorize("Condutor", "Excluir")]
        [HttpDelete("excluirCondutor/{id:guid}")]        
        public async Task<ActionResult<CondutorViewModel>> ExcluirCondutor(Guid id)
        {
            var condutor = await _condutorAppService.ObterCondutorPorId(id);

            if (condutor == null) 
            {
                CondutorNulo();
                return CustomResponse(condutor);
            }            

            await _condutorAppService.ExcluirCondutor(condutor);

            return CustomResponse(condutor);
        }

        private void CondutorNulo()
        {
            NotificarErro("Não foi possível localizar o condutor");            
        }
    }
}
