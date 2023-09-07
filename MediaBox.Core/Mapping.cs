namespace MediaBox.Core;
public static class Mapping
{
    public static IMapper Mapper => Lazy.Value;

    private static readonly Lazy<IMapper> Lazy = new(() =>
    {
        MapperConfiguration config = new(cfg =>
        {
            // This line ensures that internal properties are also mapped over.
            cfg.ShouldMapProperty = p => p.GetMethod is not null && (p.GetMethod.IsPublic || p.GetMethod.IsAssembly);
            cfg.AddProfile<MappingProfile>();
        });

        IMapper mapper = config.CreateMapper();

        return mapper;
    });
}

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Media, MediaView>();
        CreateMap<Movie, MovieView>();
        CreateMap<TvShow, TvShowView>();
        CreateMap<TvShowSeason, TvShowSeasonView>();
        CreateMap<TvShowEpisode, TvShowEpisodeView>();
    }
}