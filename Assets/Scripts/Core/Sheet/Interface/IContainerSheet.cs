using Cathei.BakingSheet;
using static SheetContainer;
public interface IContainerSheet
{
    public void CreateSheet<T>(T sheet);

    public void Add<T>(T sheet);

    public void Remove<T>(T sheet);

}
