﻿using static Smartwyre.DeveloperTest.Core.Utils.Enums;

namespace Smartwyre.DeveloperTest.Core.Data.Models;

public class Product
{
    public int Id { get; set; }
    public string Identifier { get; set; }
    public decimal Price { get; set; }
    public string Uom { get; set; }
    public SupportedIncentiveType SupportedIncentives { get; set; }
}
