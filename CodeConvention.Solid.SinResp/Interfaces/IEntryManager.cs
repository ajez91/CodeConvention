namespace CodeConvention.Solid.SinResp.Interfaces
{
    public interface IEntryManager<T>
    {
        void AddEntry(T entry);
        void RemoveEntryAt(int index);
    }
}
