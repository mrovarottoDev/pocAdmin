﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocAdmin.Infrastructure.Db
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
