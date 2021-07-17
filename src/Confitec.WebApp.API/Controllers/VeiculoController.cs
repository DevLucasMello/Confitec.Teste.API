using Confitec.Condutor.Application.Services;
using Confitec.Core.Messages;
using Confitec.Veiculo.Application.Services;
using Confitec.Veiculo.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.WebApp.API.Controllers
{
    [Route("v1/veiculo")]
    public class VeiculoController : MainController
    {
        public readonly IVeiculoAppService _veiculoAppService;
        public readonly ICondutorAppService _condutorAppService;

        public VeiculoController(IVeiculoAppService veiculoAppService, ICondutorAppService condutorAppService, INotificador notificador) : base(notificador)
        {
            _veiculoAppService = veiculoAppService;
            _condutorAppService = condutorAppService;
        }

        [HttpGet("obterTodos")]        
        public async Task<IEnumerable<VeiculoViewModel>> ObterTodosVeiculos()
        {
            var veiculos = await _veiculoAppService.ObterTodosVeiculos();
            return veiculos;
        }

        [HttpGet("obterPorCPF/{cpf}")]        
        public async Task<ActionResult<IEnumerable<VeiculoViewModel>>> ObterVeiculosPorCPF(string cpf)
        {
            var veiculos = await _veiculoAppService.ObterVeiculosPorCPF(cpf);

            if (veiculos == null)
            {
                NotificarErro("Não foi possível localizar os veículos para o CPF informado");
                return CustomResponse();
            } 
            return CustomResponse(veiculos);
        }

        [HttpGet("obterPorId/{id:guid}")]        
        public async Task<ActionResult<VeiculoViewModel>> ObterVeiculoPorId(Guid id)
        {
            var veiculo = await _veiculoAppService.ObterVeiculoPorId(id);

            if (veiculo == null) VeiculoNulo();

            return CustomResponse(veiculo);
        }

        [HttpPost("adicionarVeiculo")]        
        public async Task<ActionResult<VeiculoViewModel>> CadastrarVeiculo(VeiculoViewModel veiculoViewModel)
        {
            var condutor = await _condutorAppService.ObterCondutorPorId(veiculoViewModel.IdCondutor);

            if (condutor == null)
            {
                NotificarErro("Não foi possível localizar o registro do condutor informado");
                return CustomResponse(veiculoViewModel);
            }
            else if (condutor.CPF != veiculoViewModel.CPFCondutor)
            {
                NotificarErro("CPF do condutor informado é diferente do cadastro");
                return CustomResponse(veiculoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);            

            await _veiculoAppService.AdicionarVeiculo(veiculoViewModel);

            return CustomResponse(veiculoViewModel);
        }

        [HttpPut("atualizarVeiculo/{id:guid}")]        
        public async Task<ActionResult<VeiculoViewModel>> AtualizarVeiculo(Guid id, VeiculoViewModel veiculoViewModel)
        {
            if (id != veiculoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(veiculoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);            

            await _veiculoAppService.AtualizarVeiculo(veiculoViewModel);

            return CustomResponse(veiculoViewModel);
        }

        [HttpDelete("excluirVeiculo/{id:guid}")]        
        public async Task<ActionResult<VeiculoViewModel>> ExcluirVeiculo(Guid id)
        { 
            var veiculo = await _veiculoAppService.ObterVeiculoPorId(id);

            if (veiculo == null)
            {
                VeiculoNulo();
                return CustomResponse(veiculo);
            }

            await _veiculoAppService.ExcluirVeiculo(veiculo);

            return CustomResponse(veiculo);
        }

        private void VeiculoNulo()
        {
            NotificarErro("Não foi possível localizar o veículo");
        }
    }
}
