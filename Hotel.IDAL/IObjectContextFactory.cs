using System.Data.Objects;

namespace Hotel.IDAL {
    public interface IObjectContextFactory {
        ObjectContext GetCurrentObjectContext();
    }
}
