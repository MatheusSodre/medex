namespace Medex.Data.Contract
{
    public interface IParse<O,D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
