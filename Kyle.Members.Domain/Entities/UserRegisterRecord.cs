﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyle.Members.Domain
{
    [Table("UserRegisterRecord")]
    public class UserRegisterRecord
    {
        public UserRegisterRecord()
        {
            RecordId = Guid.NewGuid();
            AddDate = DateTime.Now;
        }

        public UserRegisterRecord(Guid userId, Guid tenantId) 
        {
            UserId = userId;
            TenantId = tenantId;
            RecordId = Guid.NewGuid();
            AddDate = DateTime.Now;
        }

        [Key]
        public Guid RecordId { get; set; }

        public DateTime AddDate { get; set; }

        public Guid UserId { get; set; }

        public Guid TenantId { get; set; }
    }
}
