namespace PadelTrialSchedule.Application.Contracts;

public sealed record LookupOptionDto(string Id, string Name, string? ParentId = null);
