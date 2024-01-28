using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace recipes.Data;

public partial class MyrecipesContext : DbContext
{
    public MyrecipesContext()
    {
    }

    public MyrecipesContext(DbContextOptions<MyrecipesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<IngredientsRecipe> IngredientsRecipes { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       
        => optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("CATEGORY_NAME");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IngredientName)
                .HasMaxLength(50)
                .HasColumnName("INGREDIENT_NAME");
        });

        modelBuilder.Entity<IngredientsRecipe>(entity =>
        {
            entity.ToTable("Ingredients_Recipes");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Comments)
                .HasMaxLength(50)
                .HasColumnName("COMMENTS");
            entity.Property(e => e.IngredientId).HasColumnName("INGREDIENT_ID");
            entity.Property(e => e.Quantity)
                .HasMaxLength(50)
                .HasColumnName("QUANTITY");
            entity.Property(e => e.RecipeId).HasColumnName("RECIPE_ID");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.IngredientsRecipes)
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("FK_Ingredients_Recipes_Ingredients");

            entity.HasOne(d => d.Recipe).WithMany(p => p.IngredientsRecipes)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK_Ingredients_Recipes_Recipes");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");
            entity.Property(e => e.Favourite).HasColumnName("FAVOURITE");
            entity.Property(e => e.Implementation).HasColumnName("IMPLEMENTATION");
            entity.Property(e => e.Made).HasColumnName("MADE");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .HasColumnName("POSITION");
            entity.Property(e => e.RecipeName)
                .HasMaxLength(100)
                .HasColumnName("RECIPE_NAME");

            entity.HasOne(d => d.Category).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recipes_Categories");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
