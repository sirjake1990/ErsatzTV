namespace ErsatzTV.Core.Api.Watermarks;

public record WatermarkResponseModel(
    int Id,
    string Name,
    string Image,
    string Mode,
    string Location);
