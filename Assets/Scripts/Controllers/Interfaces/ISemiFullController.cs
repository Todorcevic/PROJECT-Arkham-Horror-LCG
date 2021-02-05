namespace Arkham.Controllers
{
    public interface ISemiFullController<in T> : IClickController<T>, IHoverController<T>
    {
    }
}
