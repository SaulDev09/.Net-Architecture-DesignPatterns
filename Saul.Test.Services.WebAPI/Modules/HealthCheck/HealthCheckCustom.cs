﻿using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Saul.Test.Services.WebAPI.Modules.HealthCheck
{
    public class HealthCheckCustom : IHealthCheck
    {
        private readonly Random _random = new Random();

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var responseTime = _random.Next(1, 300);
            if (responseTime < 100)
            {
                return Task.FromResult(HealthCheckResult.Healthy("Healthy result from HealthCheckCustom"));
            }
            else if (responseTime < 200)
            {
                return Task.FromResult(HealthCheckResult.Degraded("Degraded result from HealthCheckCustom"));
            }
            return Task.FromResult(HealthCheckResult.Unhealthy("UnHealthy result from HealthCheckCustom"));
        }
    }
}
