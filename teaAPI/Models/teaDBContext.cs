using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace teaAPI.Models
{
    public partial class teaDBContext : DbContext
    {
        public teaDBContext()
        {
        }

        public teaDBContext(DbContextOptions<teaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Todo> Todo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 
            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.NoteId).HasColumnName("note_id");


                entity.Property(e => e.NoteDate)
                    .HasColumnName("note_date")
                    .HasColumnType("date");

                entity.Property(e => e.NoteDescription)
                    .HasColumnName("note_description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoteTitle)
                    .IsRequired()
                    .HasColumnName("note_title")
                    .HasMaxLength(20)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Todo>(entity =>
            {
                entity.Property(e => e.TodoId).HasColumnName("todo_id");


                entity.Property(e => e.IsCompleted).HasColumnName("is_completed");

                entity.Property(e => e.TodoDate)
                    .HasColumnName("todo_date")
                    .HasColumnType("date");

                entity.Property(e => e.TodoDescription)
                    .HasColumnName("todo_description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TodoTitle)
                    .IsRequired()
                    .HasColumnName("todo_title")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
