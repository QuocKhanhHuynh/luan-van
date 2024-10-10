﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerPlatform.Domain.Entity
{
    public class JobSkill
    {
        public int JobId { get; set; }
        public int SkillId  { get; set; }
        public Job Job { get; set; }
        public SKill SKill { get; set; }
    }
}
