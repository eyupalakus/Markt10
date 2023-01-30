using Markt10.DataAccess.Data;
using Markt10.DataAccess.Repository;
using Markt10.DataAccess.Repository.IRepository;
using Markt10.Repository.IRepository;

namespace Markt10.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly Markt10DbContext _db;
        public UnitofWork(Markt10DbContext db)
        {
            _db = db;
            accessory = new Accessory(_db);
            computer = new Computer(_db);
            housefold = new Housefold(_db);
            phone = new Phone(_db);
            tv = new Tv(_db);
        }
        public IAccessory accessory { get;private set; }

        public IComputer computer { get; private set; }

        public IHousefold housefold { get; private set; }

        public IPhone phone { get; private set; }

        public ITv tv { get; private set; }
    }
}
