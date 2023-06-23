using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BuiNamAnh0031.Models;

    public class SQLite : DbContext
    {
        public SQLite (DbContextOptions<SQLite> options)
            : base(options)
        {
        }

        public DbSet<BuiNamAnh0031.Models.BNALopHoc> BNALopHoc { get; set; } = default!;

        public DbSet<BuiNamAnh0031.Models.BNASinhVien> BNASinhVien { get; set; } = default!;
    }
