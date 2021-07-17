using AutoMapper;
using Confitec.Core.Messages;
using Confitec.Veiculo.Application.ViewModels;
using Confitec.Veiculo.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Confitec.Veiculo.Domain.Veiculo;

namespace Confitec.Veiculo.Application.Services
{
    public class VeiculoAppService : BaseService, IVeiculoAppService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public VeiculoAppService(IVeiculoRepository veiculoRepository, IMapper mapper, INotificador notificador) : base(notificador)
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

        public async Task<IEnumerable<VeiculoViewModel>> ObterVeiculosPorPlaca(string placa)
        {
            return _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterPorPlaca(placa));
        }

        public async Task<VeiculoViewModel> ObterVeiculoPorId(Guid id)
        {
            return _mapper.Map<VeiculoViewModel>(await _veiculoRepository.ObterPorId(id));
        }

        public async Task<bool> AdicionarVeiculo(VeiculoViewModel veiculoViewModel)
        {
            var veiculo = _mapper.Map<Domain.Veiculo>(veiculoViewModel);

            if (!ExecutarValidacao(new VeiculoValidation(), veiculo)) return false;

            _veiculoRepository.Adicionar(veiculo);

            return await _veiculoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> AtualizarVeiculo(VeiculoViewModel veiculoViewModel)
        {
            var veiculo = _mapper.Map<Domain.Veiculo>(veiculoViewModel);

            if (!ExecutarValidacao(new VeiculoValidation(), veiculo)) return false;

            _veiculoRepository.Atualizar(veiculo);

            return await _veiculoRepository.UnitOfWork.Commit();
        }        

        public async Task<bool> ExcluirVeiculo(VeiculoViewModel veiculoViewModel)
        {
            var veiculo = _mapper.Map<Domain.Veiculo>(veiculoViewModel);
            _veiculoRepository.Excluir(veiculo);

            return await _veiculoRepository.UnitOfWork.Commit();
        }      

        public void Dispose()
        {
            _veiculoRepository?.Dispose();
        }
    }
}
