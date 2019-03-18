using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.WEB.Servicos
{
    public class SendingAMessageService : IHostedService, IDisposable
    {
        /// <summary>Mensagem do fluxo</summary>
        private readonly ILogger _logger;

        /// <summary>Atributo que Ativa/Desativa o método que tem o escopo do servico</summary>
        private Timer _timer;

        /// <summary>
        /// Método construtor com uma injeção de dependencia
        /// </summary>
        /// <param name="logger">Classe responsavel por mandar mensagem do fluxo</param>
        public SendingAMessageService(ILogger<SendingAMessageService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Método padrão do IHostedService, possui a logica para iniciar tarefas em segundo plano!
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("1 - O serviço de segundo plano do cronômetro está iniciando.");

            /*Timer recebe um CallBack, mais uma definição de tempo*/
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            /*Obtém uma tarefa que já foi concluída com sucesso*/
            return Task.CompletedTask;
        }

        /// <summary>Método da tarefa</summary>
        public void DoWork(object state)
        {
            _logger.LogInformation("2 - O serviço de processamento com escopo está funcionando.");
        }

        /// <summary>
        /// Método padrão do IHostedService que para a tarefa!
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("3 - O serviço de segundo plano do cronômetro está sendo interrompido.");

            /*Altera o horário de início e o intervalo entre as chamadas de método para um cronômetro*/
            _timer?.Change(Timeout.Infinite, 0);

            /*Obtém uma tarefa que já foi concluída com sucesso*/
            return Task.CompletedTask;
        }

        /// <summary>???</summary>
        public void Dispose()
        {
           _timer?.Dispose();
        }        
        
    }
}
