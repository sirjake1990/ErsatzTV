using ErsatzTV.Core.Api.Watermarks;

namespace ErsatzTV.Application.Watermarks;

public record GetAllWatermarksForApi : IRequest<List<WatermarkResponseModel>>;
