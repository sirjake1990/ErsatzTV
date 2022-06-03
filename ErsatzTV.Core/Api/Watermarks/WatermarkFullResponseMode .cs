namespace ErsatzTV.Core.Api.Watermarks;

public record WatermarkFullResponseModel(
    int Id,
    string Name,
    string Image,
    string Mode,
    string Location);
