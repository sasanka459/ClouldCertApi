using System;
using System.Collections.Generic;

namespace qansapi.Models;

public partial class Result
{
    public int ResultId { get; set; }

    public int? ExamId { get; set; }

    public int? UserId { get; set; }

    public int? Score { get; set; }

    public string? Answers { get; set; }

    public virtual Exam? Exam { get; set; }

    public virtual User? User { get; set; }
}
