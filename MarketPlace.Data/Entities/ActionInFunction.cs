﻿using MarketPlace.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketPlace.Data.Entities
{
    [Table("ActionInFunctions")]
    public class ActionInFunction:DomainEntity<int>
    {
        public int FunctionId { get; set; }
        public int ActionId { get; set; }
        [ForeignKey("FunctionId")]
        public virtual Function Function { get; set; }
        [ForeignKey("ActionId")]
        public virtual DoAction DoAction { get; set; }
    }
}
