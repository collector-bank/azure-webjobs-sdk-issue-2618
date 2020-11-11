using System.Threading.Tasks;

namespace MyWebJob
{
    public interface IMyService
    {
        Task DoSqlStuff(string data);
    }

    public class MyService : IMyService
    {
        private readonly MyDbContext _myDbContext;

        public MyService(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task DoSqlStuff(string data)
        {
            _myDbContext.RowItems.Add(new RowItem { Data = data });
            await _myDbContext.SaveChangesAsync();
        }
    }
}
