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
        //Models to ViewModels
        CreateMap<Source, SourceView>()
            .AfterMap((src, dest) => dest.Type = src.Type.Humanize());
        CreateMap<Media, MediaView>();
        CreateMap<Movie, MovieView>();
        CreateMap<TvShow, TvShowView>();
        CreateMap<TvShowSeason, TvShowSeasonView>();
        CreateMap<TvShowEpisode, TvShowEpisodeView>();
        CreateMap<MediaInformation, MediaInformationView>();

        //ApiModels to Models
        CreateMap<ApiMedia, MediaInformation>()
            .AfterMap((src, dest) =>
            {
                if (!string.IsNullOrWhiteSpace(src.PrimaryLanguage) && !string.IsNullOrWhiteSpace(src.Name))
                {
                    dest.Names.Add(src.PrimaryLanguage, src.Name);
                }

                if (src.Translations is not null)
                {
                    foreach (PropertyInfo prop in src.Translations.GetType().GetProperties())
                    {
                        try
                        {
                            object? value = prop.GetValue(src.Translations);

                            if (value is null)
                            {
                                continue;
                            }

                            dest.Names.Add(prop.Name, (string)value);
                        }
                        catch (Exception exception)
                        {
                            Log.Fatal(exception);
                        }
                    }
                }

                if (src.Overviews is not null)
                {
                    foreach (PropertyInfo prop in src.Overviews.GetType().GetProperties())
                    {
                        try
                        {
                            object? value = prop.GetValue(src.Overviews);

                            if (value is null)
                            {
                                continue;
                            }

                            dest.Overviews.Add(prop.Name, (string)value);
                        }
                        catch (Exception exception)
                        {
                            Log.Fatal(exception);
                        }
                    }
                }
            });
    }
}