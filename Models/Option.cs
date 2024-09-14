using System;
using System.Collections.Generic;

namespace qansapi.Models;

public partial class Option
{
    public int OptionId { get; set; }

    public int? QuestionId { get; set; }

    public string OptionText { get; set; } = null!;

    public bool IsCorrect { get; set; }

    public virtual Question? Question { get; set; }
}
