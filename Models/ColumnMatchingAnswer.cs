using System;
using System.Collections.Generic;

namespace qansapi.Models;

public partial class ColumnMatchingAnswer
{
    public int CmAnswerId { get; set; }

    public int? CmQuestionId { get; set; }

    public int? ChapterId { get; set; }

    public int? ColumnAId { get; set; }

    public int? ColumnBId { get; set; }

    public virtual Chapter? Chapter { get; set; }

    public virtual ColumnMatchingQuestion? CmQuestion { get; set; }
}
