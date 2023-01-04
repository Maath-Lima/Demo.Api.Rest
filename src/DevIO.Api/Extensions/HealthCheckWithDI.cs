using DevIO.Business.Intefaces;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DevIO.Api.Extensions
{
    public class HealthCheckWithDI : IHealthCheck
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public HealthCheckWithDI(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var fornecedores = await _fornecedorRepository.ObterTodos();

            return fornecedores.Count > 0 ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy();
        }
    }
}
