using Confitec.Veiculo.Application.Services;
using Confitec.Veiculo.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.WebApp.API.Controllers
{
    [Route("v1/veiculo")]
    public class VeiculoController : ControllerBase
    {
        public readonly IVeiculoAppService _veiculoAppService;

        public VeiculoController(IVeiculoAppService veiculoAppService)
        {
            _veiculoAppService = veiculoAppService;
        }

        [HttpGet]
        [Route("obterTodos")]
        //[Authorize]
        public async Task<IEnumerable<VeiculoViewModel>> Get()
        {
            var veiculos = await _veiculoAppService.ObterTodosVeiculos();
            return veiculos;
        }

        [HttpGet]
        [Route("obterPorCPF/{cpf}")]
        public async Task<IEnumerable<VeiculoViewModel>> GetByVeiculosPorCPF(string cpf)
        {
            var veiculos = await _veiculoAppService.ObterVeiculosPorCPF(cpf);

            if (veiculos == null) return (IEnumerable<VeiculoViewModel>)NotFound("Não foi possível localizar os veículos para o CPF informado");

            return veiculos;
        }

        [HttpGet]
        [Route("obterPorId/{id:guid}")]
        public async Task<ActionResult<VeiculoViewModel>> GetById(Guid id)
        {
            var veiculo = await _veiculoAppService.ObterVeiculoPorId(id);

            if (veiculo == null) return NotFound("Não foi possível localizar o veículo");

            return veiculo;
        }

        [HttpGet]
        [Route("obterPorPlaca/{placa}")]
        public async Task<ActionResult<VeiculoViewModel>> GetByCPF(string placa)
        {
            var veiculo = await _veiculoAppService.ObterVeiculoPorPlaca(placa);

            if (veiculo == null) return NotFound("Não foi possível localizar o veículo");

            return veiculo;
        }

        [HttpPost]
        [Route("adicionarVeiculo")]
        public async Task<ActionResult<VeiculoViewModel>> Post(VeiculoViewModel veiculoViewModel)
        {
            if (!ModelState.IsValid) return BadRequest("O formulário possui dados inválidos");

            var veiculo = await _veiculoAppService.ObterVeiculoPorPlaca(veiculoViewModel.Placa);

            if(veiculo != null)
            {
                if (veiculo.Placa == veiculoViewModel.Placa) return BadRequest("Placa já cadastrado");
            }

            await _veiculoAppService.AdicionarVeiculo(veiculoViewModel);

            return veiculoViewModel;
        }

        [HttpPut]
        [Route("atualizarVeiculo")]
        public async Task<ActionResult<VeiculoViewModel>> Put(VeiculoViewModel veiculoViewModel)
        {
            if (!ModelState.IsValid) return BadRequest("O formulário possui dados inválidos");

            var veiculo = await _veiculoAppService.ObterVeiculoPorId(veiculoViewModel.Id);

            if (veiculo == null)
            {
                return NotFound("Não foi possível localizar o veículo");
            }
            else 
            {
                if (veiculo.Placa == veiculoViewModel.Placa) return BadRequest("Placa já cadastrado");
            }

            await _veiculoAppService.AtualizarVeiculo(veiculoViewModel);

            return veiculoViewModel;
        }

        [HttpDelete]
        [Route("excluirVeiculo/{id:guid}")]
        public async Task<ActionResult<VeiculoViewModel>> Delete(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest("O formulário possui dados inválidos");

            var veiculo = await _veiculoAppService.ObterVeiculoPorId(id);

            await _veiculoAppService.ExcluirVeiculo(veiculo);

            return veiculo;
        }
    }
}
