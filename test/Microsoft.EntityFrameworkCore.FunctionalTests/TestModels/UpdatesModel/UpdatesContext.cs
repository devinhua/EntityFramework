﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Microsoft.EntityFrameworkCore.FunctionalTests.TestModels.UpdatesModel
{
    public class UpdatesContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public UpdatesContext(
            IServiceProvider serviceProvider,
            DbContextOptions options)
            : base(serviceProvider, options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne<Category>().WithOne()
                .HasForeignKey<Product>(e => e.DependentId)
                .HasPrincipalKey<Category>(e => e.PrincipalId);

            modelBuilder.Entity<Product>()
                .Property(e => e.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Category>()
                .Property(e => e.Id)
                .ValueGeneratedNever();
        }
    }
}