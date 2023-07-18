namespace Smartwyre.DeveloperTest.Core.Api.Request;

public class CalculateRebate
{
    public string RebateIdentifier { get; set; }

    public string ProductIdentifier { get; set; }

    public decimal Volume { get; set; }
}
