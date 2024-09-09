using System;
using System.Collections.Generic;

namespace qansapi.Models;

public partial class Scenario
{
    public int ScenarioId { get; set; }

    public string ScenarioText { get; set; } = null!;

    public string? ReferenceImageUrl { get; set; }

    public string? ReferenceLink { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
