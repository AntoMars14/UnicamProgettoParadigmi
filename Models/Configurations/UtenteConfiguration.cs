﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamProgettoParadigmi.Models.Entities;

namespace UnicamProgettoParadigmi.Models.Configurations
{
    public class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.ToTable("Utenti");
            builder.HasKey(k => k.IdUtente);
        }
    }
}
