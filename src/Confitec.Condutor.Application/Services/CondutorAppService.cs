using AutoMapper;
using Confitec.Condutor.Application.ViewModels;
using Confitec.Condutor.Domain;
using Confitec.Core.Messages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Confitec.Condutor.Domain.Condutor;
using static Confitec.Motorista.Domain.Nome;

namespace Confitec.Condutor.Application.Services
{
    public class CondutorAppService : BaseService, ICondutorAppService
    {
        private readonly ICondutorRepository _condutorRepository;
        private readonly IMapper _mapper;

        public CondutorAppService(ICondutorRepository condutorRepository, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _condutorRepository = condutorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CondutorViewModel>> ObterTodosCondutores()
        {
            return _mapper.Map<IEnumerable<CondutorViewModel>>(await _condutorRepository.ObterTodos());
        }        

        public async Task<CondutorViewModel> ObterCondutorPorId(Guid id)
        {
            return _mapper.Map<CondutorViewModel>(await _condutorRepository.ObterPorId(id));
        }

        public async Task<CondutorViewModel> ObterCondutorPorCPF(string cpf)
        {
            return _mapper.Map<CondutorViewModel>(await _condutorRepository.ObterPorCPF(cpf));
        }

        public async Task<bool> AdicionarCondutor(CondutorViewModel condutorViewModel)
        {
            var condutor = _mapper.Map<Domain.Condutor>(condutorViewModel);

            var validarCondutor = !ExecutarValidacao(new CondutorValidation(), condutor);
            var validarCondutorNome = !ExecutarValidacao(new NomeValidation(), condutor.Nome);

            if (validarCondutor || validarCondutorNome) return false;

            if (await VerificarCnhCpf(condutorViewModel)) return false;

            _condutorRepository.Adicionar(condutor);

            return await _condutorRepository.UnitOfWork.Commit();            
        }

        public async Task<bool> AtualizarCondutor(CondutorViewModel condutorViewModel)
        {
            var condutor = _mapper.Map<Domain.Condutor>(condutorViewModel);
            var validarCondutor = !ExecutarValidacao(new CondutorValidation(), condutor);
            var validarCondutorNome = !ExecutarValidacao(new NomeValidation(), condutor.Nome);

            if (validarCondutor || validarCondutorNome) return false;

            if (await VerificarCnhCpf(condutorViewModel)) return false;

            _condutorRepository.Atualizar(condutor);

            return await _condutorRepository.UnitOfWork.Commit();            
        }        

        public async Task<bool> ExcluirCondutor(CondutorViewModel condutorViewModel)
        {            
            var condutor = _mapper.Map<Domain.Condutor>(condutorViewModel);
            _condutorRepository.Excluir(condutor);

            return await _condutorRepository.UnitOfWork.Commit();           
        }                       

        public void Dispose()
        {
            _condutorRepository?.Dispose();
        }

        private async Task<bool> VerificarCnhCpf(CondutorViewModel condutorViewModel)
        {
            var condutores = await ObterTodosCondutores();
            var cpf = false;
            var cnh = false;

            foreach(var condutor in condutores)
            { 
                if (condutor.Id != condutorViewModel.Id)
                {
                    if (condutor.CPF == condutorViewModel.CPF)
                    {
                        Notificar("CPF já cadastrado");
                        cpf = true;
                    }
                    if (condutor.CNH == condutorViewModel.CNH)
                    {
                        Notificar("CNH já cadastrada");
                        cnh = true;
                    }
                }                                               
            }

            if (cpf || cnh) return true;
            
            return false;
        }
    }
}
