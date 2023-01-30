using Markt10.DataAccess.Repository.IRepository;

namespace Markt10.Repository.IRepository
{
    public interface IUnitofWork
    {
        IAccessory accessory { get; }
        IComputer computer { get; }
        IHousefold housefold { get; }
        IPhone phone { get; }
        ITv tv { get; }
    }
}
