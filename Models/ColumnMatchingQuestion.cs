using System;
using System.Collections.Generic;

namespace qansapi.Models;

public partial class ColumnMatchingQuestion
{
    public int CmQuestionId { get; set; }

    public int? QuestionId { get; set; }

    public string ColumnAText { get; set; } = null!;

    public string ColumnBText { get; set; } = null!;

    public string? ReferenceImageUrl { get; set; }

    public string? ReferenceLink { get; set; }

    public virtual ICollection<ColumnMatchingAnswer> ColumnMatchingAnswers { get; set; } = new List<ColumnMatchingAnswer>();

    public virtual Question? Question { get; set; }
}
