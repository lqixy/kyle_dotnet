using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Kyle.Infrastructure.Mapper.Test;

[TestClass]
public class UnitTest1: TestBase
{
    private readonly IMapper _mapper;

    public UnitTest1()
    {
        _mapper = Provider.GetRequiredService<IMapper>();
    }
    [TestMethod]
    public void TestMethod1()
    {
        var entity = new ItemEntity() { Id = Guid.NewGuid(), Time = DateTime.Now };

        var dto = _mapper.Map<ItemDto>(entity);
        Assert.IsNotNull(dto);
    }
}