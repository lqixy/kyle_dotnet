using AutoMapper;

namespace Kyle.Infrastructure.Mapper.Test;

public class ItemProfile: Profile
{
    public ItemProfile()
    {
        CreateMap<ItemDto, ItemEntity>()
            .AfterMap(((dto, entity) =>
            {
                dto.Time = $"{entity.Time:yyyy-MM-dd HH:mm:ss}";
            }));
        CreateMap<ItemEntity, ItemDto>();
    }
}