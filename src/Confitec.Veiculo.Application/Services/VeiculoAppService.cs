using AutoMapper;
using Confitec.Veiculo.Application.ViewModels;
using Confitec.Veiculo.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Veiculo.Application.Services
{
    public class VeiculoAppService : IVeiculoAppService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public VeiculoAppService(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VeiculoViewModel>> ObterTodosVeiculos()
        {
            return _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterTodos());
        }

        public async Task<IEnumerable<VeiculoViewModel>> ObterVeiculosPorCPF(string cpf)
        {
            return _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterPorCPF(cpf));
        }

        public async Task<VeiculoViewModel> ObterVeiculoPorId(Guid id)
        {
            return _mapper.Map<VeiculoViewModel>(await _veiculoRepository.ObterPorId(id));
        }

        public async Task<VeiculoViewModel> ObterVeiculoPorPlaca(string placa)
        {
            return _mapper.Map<VeiculoViewModel>(await _veiculoRepository.ObterPorPlaca(placa));
        }

        public async Task AdicionarVeiculo(VeiculoViewModel veiculoViewModel)
        {
            var veiculo = _mapper.Map<Domain.Veiculo>(veiculoViewModel);
            _veiculoRepository.Adicionar(veiculo);

            await _veiculoRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarVeiculo(VeiculoViewModel veiculoViewModel)
        {
            var veiculo = _mapper.Map<Domain.Veiculo>(veiculoViewModel);
            _veiculoRepository.Atualizar(veiculo);

            await _veiculoRepository.UnitOfWork.Commit();
        }        

        public async Task ExcluirVeiculo(VeiculoViewModel veiculoViewModel)
        {
            var veiculo = _mapper.Map<Domain.Veiculo>(veiculoViewModel);
            _veiculoRepository.Excluir(veiculo);

            await _veiculoRepository.UnitOfWork.Commit();
        }      

        public void Dispose()
        {
            _veiculoRepository?.Dispose();
        }
    }
}
