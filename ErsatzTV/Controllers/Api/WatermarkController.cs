using ErsatzTV.Core;
using ErsatzTV.Core.Domain;
using ErsatzTV.Core.Api.Watermarks;
using ErsatzTV.Application.Watermarks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ErsatzTV.FFmpeg.State;

namespace ErsatzTV.Controllers.Api;

[ApiController]
public class WatermarkController
{
    private readonly IMediator _mediator;

    public WatermarkController(IMediator mediator) => _mediator = mediator;

    [HttpGet("/api/watermarks")]
    public async Task<List<WatermarkResponseModel>> GetAll() =>
        await _mediator.Send(new GetAllWatermarksForApi());

    [HttpPost("/api/watermarks/new")]
    public async Task<Either<BaseError, CreateWatermarkResult>> AddOne(
    JObject data
    )
    {
        return await _mediator.Send(
            new CreateWatermarkForApi(
                data.GetValue("Name").ToString(),
                data.GetValue("Image").ToString(),
                (ChannelWatermarkMode)(int)data.GetValue("Mode"),
                (ChannelWatermarkImageSource)(int)data.GetValue("ImageSource"),
                (WatermarkLocation)(int)data.GetValue("Location"),
                (WatermarkSize)(int)data.GetValue("Size"),
                (int)data.GetValue("Width"),
                (int)data.GetValue("HorizontalMargin"),
                (int)data.GetValue("VerticalMargin"),
                (int)data.GetValue("FrequencyMinutes"),
                (int)data.GetValue("DurationSeconds"),
                (int)data.GetValue("Opacity")
                )
            );
    }
}
