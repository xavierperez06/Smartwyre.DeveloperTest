namespace Smartwyre.DeveloperTest.Core.Services.Interfaces;

public interface IRebateService
{
    Api.Response.CalculateRebate Calculate(Api.Request.CalculateRebate request);
}
