using ErsatzTV.Core.Domain;
using ErsatzTV.Core.Api.Watermarks;

namespace ErsatzTV.Application.Watermarks;

internal static class Mapper
{
    public static WatermarkViewModel ProjectToViewModel(ChannelWatermark watermark) =>
        new(
            watermark.Id,
            watermark.Image,
            watermark.Name,
            watermark.Mode,
            watermark.ImageSource,
            watermark.Location,
            watermark.Size,
            watermark.WidthPercent,
            watermark.HorizontalMarginPercent,
            watermark.VerticalMarginPercent,
            watermark.FrequencyMinutes,
            watermark.DurationSeconds,
            watermark.Opacity);

    public static WatermarkResponseModel ProjectToResponseModel(ChannelWatermark watermark) =>
        new(
            watermark.Id,
            watermark.Name,
            watermark.Image,
            watermark.Mode.ToString(),
            watermark.Location.ToString());
}
