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
    public class ListaDistribuzioneEmailConfiguration : IEntityTypeConfiguration<ListaDistribuzioneEmail>
    {
        public void Configure(EntityTypeBuilder<ListaDistribuzioneEmail> builder)
        {
            builder.ToTable("ListaDistribuzioneEmail");
            builder.HasKey(k => new {k.IdListaDistribuzione, k.IdEmail});
        }
    }
}
