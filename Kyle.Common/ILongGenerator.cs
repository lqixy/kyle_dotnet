using IdGen;

namespace Kyle.Common;

public interface ILongGenerator
{
    long Create();
}

public class LongGenerator : ILongGenerator
{
    private readonly IdGenerator _generator;

    public LongGenerator()
    {
        var options = new IdGeneratorOptions(IdStructure.Default,new DefaultTimeSource(new DateTime(2020,1,1,0,0,0,DateTimeKind.Utc)));
        _generator = new IdGenerator(0,options);
    }

    public long Create()
    {
        return _generator.CreateId();
    }
}