using ErsatzTV.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ErsatzTV.Core.Api.Watermarks;
using static ErsatzTV.Application.Watermarks.Mapper;

namespace ErsatzTV.Application.Watermarks;

public class GetAllWatermarksForApiHandler : IRequestHandler<GetAllWatermarksForApi, List<WatermarkResponseModel>>
{
    private readonly IDbContextFactory<TvContext> _dbContextFactory;

    public GetAllWatermarksForApiHandler(IDbContextFactory<TvContext> dbContextFactory) =>
        _dbContextFactory = dbContextFactory;

    public async Task<List<WatermarkResponseModel>> Handle(
        GetAllWatermarksForApi request,
        CancellationToken cancellationToken)
    {
        await using TvContext dbContext = _dbContextFactory.CreateDbContext();
        return await dbContext.ChannelWatermarks
            .ToListAsync(cancellationToken)
            .Map(list => list.Map(ProjectToResponseModel).ToList());
    }
}
