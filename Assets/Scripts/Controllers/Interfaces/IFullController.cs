namespace Arkham.Controllers
{
    public interface IFullController<in T> : IClickController<T>, IDoubleClickController<T>, IHoverController<T>
    {
    }
}