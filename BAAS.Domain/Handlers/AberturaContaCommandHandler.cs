using AutoMapper;
using Baas.Domain.Commands;
using Baas.Domain.Events;
using Baas.Domain.Helpers;
using Baas.Domain.Repositories.Contracts;
using Baas.Domain.Repositories.DTOs;
using Baas.Domain.Responses;
using BAAS.Domain.Produces;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Handlers
{
    public class AberturaContaCommandHandler : IRequestHandler<AberturaContaCommand, AberturaContaCommandResponse>
    {
        private readonly ILogger<AberturaContaCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IAccountRepository _contaRepository;

        public AberturaContaCommandHandler(ILogger<AberturaContaCommandHandler> logger, IMapper mapper, IPublishEndpoint busMessage, IAccountRepository contaRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _publishEndpoint = busMessage;
            _contaRepository = contaRepository;
        }

        public async Task<AberturaContaCommandResponse> Handle(AberturaContaCommand request, CancellationToken cancellationToken)
         {
            try
            {
                _logger.LogInformation("Iniciando a abertura de conta {@request}", request);

                AccountDTO conta = _mapper.Map<AccountDTO>(request);
                conta.Numero = GetNumeroConta();

                await _contaRepository.Insert(conta);
                
                _logger.LogInformation($"Conta {conta.ToJson()} aberta com sucesso.");
                try
                {
                    _publishEndpoint.Publish<ContaAbertaEvent>(_mapper.Map<ContaAbertaEvent>(conta))
                        .ConfigureAwait(false);
                    _logger.LogInformation("Evento de conta aberta publicado com sucesso");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ocorreu um erro ao publicar o evento de conta aberta");
                }
                return _mapper.Map<AberturaContaCommandResponse>(conta);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao publicar o evento de conta aberta");
                throw new TaskCanceledException();
            }
        }
        private string GetNumeroConta()
        {
            Random rand = new Random();
            string numericString = "";
            for (int i = 0; i < 10; i++)
            {
                numericString += rand.Next(10).ToString();
            }
            return numericString;
        }
    }
}