using System;
using System.Collections.Generic;

namespace qansapi.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public int? ChapterId { get; set; }

    public int? ScenarioId { get; set; }

    public string QuestionText { get; set; } = null!;

    public string QuestionType { get; set; } = null!;

    public string? ReferenceImageUrl { get; set; }

    public string? ReferenceLink { get; set; }

    public virtual Chapter? Chapter { get; set; }

    public virtual ICollection<ColumnMatchingQuestion> ColumnMatchingQuestions { get; set; } = new List<ColumnMatchingQuestion>();

    public virtual ICollection<Option> Options { get; set; } = new List<Option>();

    public virtual Scenario? Scenario { get; set; }
}
