﻿using System;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace capstone_backend.Models
{
  public partial class DatabaseContext : DbContext
  {
    public DbSet<Nurse> Nurse { get; set; }
    public DbSet<Recruiters> Recruiter { get; set; }

    public DbSet<User> Users { get; set; }

    private readonly IConfiguration config;

    public DatabaseContext(IConfiguration configuration)
    {
      this.config = configuration;
    }

    private string ConvertPostConnectionToConnectionString(string connection)
    {
      var _connection = connection.Replace("postgres://", String.Empty);
      var output = Regex.Split(_connection, ":|@|/");
      return $"server={output[2]};database={output[4]};User Id={output[0]}; password={output[1]}; port={output[3]}";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        var envConn = Environment.GetEnvironmentVariable("DATABASE_URL");
        var password = this.config["PASSWORD"];
        var conn = $"server=localhost;database=productionDatabase; User Id=postgres; password={password}";
        if (envConn != null)
        {
          conn = ConvertPostConnectionToConnectionString(envConn);
        }
        optionsBuilder.UseNpgsql(conn);
      }
    }



  }
}
