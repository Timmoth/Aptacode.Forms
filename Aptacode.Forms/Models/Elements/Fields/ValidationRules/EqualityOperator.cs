﻿using System;

namespace Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules
{
    [Flags]
    public enum EqualityOperator
    {
        None = 0,
        GreaterThan = 1,
        EqualTo = 2,
        LessThan = 4
    }
}