using CIDET.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CIDET.InfraStructure.DAL
{
    public class CIDETDataContext : DbContext
    {        
        public CIDETDataContext([NotNullAttribute] DbContextOptions options)
            : base(options)
        {
        }        

        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Registrando Departamentos
            //Insertando los roles por defecto            
            modelBuilder.Entity<Departamento>().HasData(
                new Departamento
                {
                    Id = 1,
                    Nombre = "Antioquia"
                },
                new Departamento
                {
                    Id = 2,
                    Nombre = "Atlántico"
                },
                new Departamento
                {
                    Id = 3,
                    Nombre = "Bolívar"
                },
                new Departamento
                {
                    Id = 4,
                    Nombre = "Bogotá"
                },
                new Departamento
                {
                    Id = 5,
                    Nombre = "Chocó"
                },
                new Departamento
                {
                    Id = 6,
                    Nombre = "Cundinamarca"
                },
                new Departamento
                {
                    Id = 7,
                    Nombre = "La Guajira"
                },
                new Departamento
                {
                    Id = 8,
                    Nombre = "Nariño"
                },
                new Departamento
                {
                    Id = 9,
                    Nombre = "Norte de Santander"
                },
                new Departamento
                {
                    Id = 10,
                    Nombre = "Quindío"
                },
                new Departamento
                {
                    Id = 11,
                    Nombre = "San Andrés y Providencia"
                },
                new Departamento
                {
                    Id = 12,
                    Nombre = "Santander"
                },
                new Departamento
                {
                    Id = 13,
                    Nombre = "Sucre"
                },
                new Departamento
                {
                    Id = 14,
                    Nombre = "Tolima"
                },
                new Departamento
                {
                    Id = 15,
                    Nombre = "Valle del Cauca"
                }
            );
            #endregion

            //Creando indices en la tabla principal.
            modelBuilder.Entity<Municipio>()
                .HasIndex(mun => new { mun.Nombre });

            modelBuilder.Entity<Municipio>()
                .HasIndex(mun => new { mun.CodigoDANE });

            modelBuilder.Entity<Departamento>()
                .HasIndex(dep => new { dep.Nombre });

        }

    }
}
