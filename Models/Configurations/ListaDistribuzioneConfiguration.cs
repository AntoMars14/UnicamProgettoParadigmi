using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamProgettoParadigmi.Models.Entities;

namespace UnicamProgettoParadigmi.Models.Configurations
{
    public class ListaDistribuzioneConfiguration : IEntityTypeConfiguration<ListaDistribuzione>
    {
        public void Configure(EntityTypeBuilder<ListaDistribuzione> builder)
        {
            builder.ToTable("ListeDistribuzione");
            builder.HasKey(k => k.IdListaDistribuzione);
            builder.HasOne(x => x.Proprietario).WithMany(x => x.ListeDistribuzione).HasForeignKey(x => x.IdProprietario);
        }
    }
}
