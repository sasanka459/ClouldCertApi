using System;
using System.Collections.Generic;

namespace qansapi.Models;

public partial class Exam
{
    public int ExamId { get; set; }

    public string ExamName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
}
