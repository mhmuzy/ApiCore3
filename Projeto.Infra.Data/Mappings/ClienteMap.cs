using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(c => c.IdCliente);

            builder.Property(c => c.IdCliente)
                .HasColumnName("IdCliente");

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Cpf)
                .HasColumnName("Cpf")
                .HasMaxLength(11)
                .IsRequired();
        }
    }
}
