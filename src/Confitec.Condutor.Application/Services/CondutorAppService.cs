using AutoMapper;
using Confitec.Condutor.Application.ViewModels;
using Confitec.Condutor.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Condutor.Application.Services
{
    public class CondutorAppService : ICondutorAppService
    {
        private readonly ICondutorRepository _condutorRepository;
        private readonly IMapper _mapper;

        public CondutorAppService(ICondutorRepository condutorRepository, IMapper mapper)
        {
            _condutorRepository = condutorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CondutorViewModel>> ObterTodosCondutores()
        {
            return _mapper.Map<IEnumerable<CondutorViewModel>>(await _condutorRepository.ObterTodos());
        }

        public async Task<IEnumerable<CondutorViewModel>> ObterCondutoresPorPlaca(string placa)
        {
            return _mapper.Map<IEnumerable<CondutorViewModel>>(await _condutorRepository.ObterPorPlaca(placa));
        }

        public async Task<CondutorViewModel> ObterCondutorPorId(Guid id)
        {
            return _mapper.Map<CondutorViewModel>(await _condutorRepository.ObterPorId(id));
        }

        public async Task<CondutorViewModel> ObterCondutorPorCPF(string cpf)
        {
            return _mapper.Map<CondutorViewModel>(await _condutorRepository.ObterPorCPF(cpf));
        }

        public async Task AdicionarCondutor(CondutorViewModel condutorViewModel)
        {
            var condutor = _mapper.Map<Domain.Condutor>(condutorViewModel);
            _condutorRepository.Adicionar(condutor);

            await _condutorRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarCondutor(CondutorViewModel condutorViewModel)
        {
            var condutor = _mapper.Map<Domain.Condutor>(condutorViewModel);
            _condutorRepository.Atualizar(condutor);

            await _condutorRepository.UnitOfWork.Commit();
        }        

        public async Task ExcluirCondutor(CondutorViewModel condutorViewModel)
        {
            var condutor = _mapper.Map<Domain.Condutor>(condutorViewModel);
            _condutorRepository.Excluir(condutor);

            await _condutorRepository.UnitOfWork.Commit();
        }                       

        public void Dispose()
        {
            _condutorRepository?.Dispose();
        }
    }
}
