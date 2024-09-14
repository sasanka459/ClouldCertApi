using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace qansapi.Models;

public partial class SqldbQansDevCetralind001Context : DbContext
{
    public SqldbQansDevCetralind001Context()
    {
    }

    public SqldbQansDevCetralind001Context(DbContextOptions<SqldbQansDevCetralind001Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<ColumnMatchingAnswer> ColumnMatchingAnswers { get; set; }

    public virtual DbSet<ColumnMatchingQuestion> ColumnMatchingQuestions { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<PasswordReset> PasswordResets { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Scenario> Scenarios { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.HasKey(e => e.ChapterId).HasName("PK__Chapters__745EFE872CAF3654");

            entity.Property(e => e.ChapterId).HasColumnName("chapter_id");
            entity.Property(e => e.ChapterName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("chapter_name");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.TopicId).HasColumnName("topic_id");

            entity.HasOne(d => d.Topic).WithMany(p => p.Chapters)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK__Chapters__topic___6EF57B66");
        });

        modelBuilder.Entity<ColumnMatchingAnswer>(entity =>
        {
            entity.HasKey(e => e.CmAnswerId).HasName("PK__Column_M__E069A83B3B98008D");

            entity.ToTable("Column_Matching_Answers");

            entity.Property(e => e.CmAnswerId).HasColumnName("cm_answer_id");
            entity.Property(e => e.ChapterId).HasColumnName("chapter_id");
            entity.Property(e => e.CmQuestionId).HasColumnName("cm_question_id");
            entity.Property(e => e.ColumnAId).HasColumnName("column_a_id");
            entity.Property(e => e.ColumnBId).HasColumnName("column_b_id");

            entity.HasOne(d => d.Chapter).WithMany(p => p.ColumnMatchingAnswers)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("FK__Column_Ma__chapt__7E37BEF6");

            entity.HasOne(d => d.CmQuestion).WithMany(p => p.ColumnMatchingAnswers)
                .HasForeignKey(d => d.CmQuestionId)
                .HasConstraintName("FK__Column_Ma__cm_qu__7D439ABD");
        });

        modelBuilder.Entity<ColumnMatchingQuestion>(entity =>
        {
            entity.HasKey(e => e.CmQuestionId).HasName("PK__Column_M__F80F4745FEB05875");

            entity.ToTable("Column_Matching_Questions");

            entity.Property(e => e.CmQuestionId).HasColumnName("cm_question_id");
            entity.Property(e => e.ColumnAText)
                .HasColumnType("text")
                .HasColumnName("column_a_text");
            entity.Property(e => e.ColumnBText)
                .HasColumnType("text")
                .HasColumnName("column_b_text");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.ReferenceImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("reference_image_url");
            entity.Property(e => e.ReferenceLink)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("reference_link");

            entity.HasOne(d => d.Question).WithMany(p => p.ColumnMatchingQuestions)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__Column_Ma__quest__7A672E12");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__Exams__9C8C7BE908EDD130");

            entity.Property(e => e.ExamId).HasColumnName("exam_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ExamName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("exam_name");

            entity.HasMany(d => d.Chapters).WithMany(p => p.Exams)
                .UsingEntity<Dictionary<string, object>>(
                    "ExamChapter",
                    r => r.HasOne<Chapter>().WithMany()
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Exam_Chap__chapt__03F0984C"),
                    l => l.HasOne<Exam>().WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Exam_Chap__exam___02FC7413"),
                    j =>
                    {
                        j.HasKey("ExamId", "ChapterId").HasName("PK__Exam_Cha__FBC9940197E69094");
                        j.ToTable("Exam_Chapters");
                        j.IndexerProperty<int>("ExamId").HasColumnName("exam_id");
                        j.IndexerProperty<int>("ChapterId").HasColumnName("chapter_id");
                    });
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PK__Options__F4EACE1B2A78D5C8");

            entity.Property(e => e.OptionId).HasColumnName("option_id");
            entity.Property(e => e.IsCorrect).HasColumnName("is_correct");
            entity.Property(e => e.OptionText)
                .HasColumnType("text")
                .HasColumnName("option_text");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");

            entity.HasOne(d => d.Question).WithMany(p => p.Options)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__Options__questio__778AC167");
        });

        modelBuilder.Entity<PasswordReset>(entity =>
        {
            entity.HasKey(e => e.ResetId).HasName("PK__Password__40FB05203F05A514");

            entity.ToTable("Password_Resets");

            entity.HasIndex(e => e.ResetToken, "UQ__Password__25F405EBA5F82801").IsUnique();

            entity.Property(e => e.ResetId).HasColumnName("reset_id");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("datetime")
                .HasColumnName("expires_at");
            entity.Property(e => e.ResetToken)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("reset_token");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.PasswordResets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Password___user___6A30C649");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__2EC21549B6618968");

            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.ChapterId).HasColumnName("chapter_id");
            entity.Property(e => e.QuestionText)
                .HasColumnType("text")
                .HasColumnName("question_text");
            entity.Property(e => e.QuestionType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("question_type");
            entity.Property(e => e.ReferenceImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("reference_image_url");
            entity.Property(e => e.ReferenceLink)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("reference_link");
            entity.Property(e => e.ScenarioId).HasColumnName("scenario_id");

            entity.HasOne(d => d.Chapter).WithMany(p => p.Questions)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("FK__Questions__chapt__73BA3083");

            entity.HasOne(d => d.Scenario).WithMany(p => p.Questions)
                .HasForeignKey(d => d.ScenarioId)
                .HasConstraintName("FK__Questions__scena__74AE54BC");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__Results__AFB3C3166B897DD9");

            entity.Property(e => e.ResultId).HasColumnName("result_id");
            entity.Property(e => e.Answers)
                .HasColumnType("text")
                .HasColumnName("answers");
            entity.Property(e => e.ExamId).HasColumnName("exam_id");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Exam).WithMany(p => p.Results)
                .HasForeignKey(d => d.ExamId)
                .HasConstraintName("FK__Results__exam_id__06CD04F7");

            entity.HasOne(d => d.User).WithMany(p => p.Results)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Results__user_id__07C12930");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__760965CC871C5C02");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__783254B197B2D9A3").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Scenario>(entity =>
        {
            entity.HasKey(e => e.ScenarioId).HasName("PK__Scenario__D56D0C7DA841648B");

            entity.Property(e => e.ScenarioId).HasColumnName("scenario_id");
            entity.Property(e => e.ReferenceImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("reference_image_url");
            entity.Property(e => e.ReferenceLink)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("reference_link");
            entity.Property(e => e.ScenarioText)
                .HasColumnType("text")
                .HasColumnName("scenario_text");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__Topics__D5DAA3E94AD3305A");

            entity.Property(e => e.TopicId).HasColumnName("topic_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.TopicName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("topic_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370FDC2AB0C2");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E61648D61E586").IsUnique();

            entity.HasIndex(e => e.MobileNo, "UQ__Users__D7B19EFA69504C3F").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__Users__F3DBC572AB47F52F").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("mobile_no");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__User_Role__role___66603565"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__User_Role__user___656C112C"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__User_Rol__6EDEA153329CDCB7");
                        j.ToTable("User_Roles");
                        j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                        j.IndexerProperty<int>("RoleId").HasColumnName("role_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
