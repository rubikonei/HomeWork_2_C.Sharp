namespace SmartHouse
{
    public interface IProgram
    {
        void Next();
        void Previous();
        void Set(int x);
    }
}