﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Logs.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Logs.Models
{
    public partial interface IAccidentesContextProcedures
    {
        Task<int> INSERTACCIDENTEAsync(string desc, int? heridos, int? fallecidos, int? veh, DateTime? fecha, int? estado, string geo, string usuario, string ciudad, string pais, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
