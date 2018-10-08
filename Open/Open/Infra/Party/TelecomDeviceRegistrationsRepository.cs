using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Data.Party;
using Open.Domain.Party;
namespace Open.Infra.Party {
    public class TelecomDeviceRegistrationsRepository : BaseRepository<
            TelecomDeviceRegistration, TelecomDeviceRegistrationData>,
        ITelecomDeviceRegistrationsRepository {

        public TelecomDeviceRegistrationsRepository(SentryDbContext c) : base(
            c?.TelecomDeviceRegistrations, c) { }
        public async Task LoadAddresses(TelecomAddress device) {
            if (device is null) return;
            var id = device.Data?.ID ?? string.Empty;
            var addresses = await dbSet.Include(x => x.Address).Where(x => x.DeviceID == id)
                .AsNoTracking().ToListAsync();
            foreach (var c in addresses)
                device.RegisteredInAddress(new GeographicAddress(c.Address));
        }
        public async Task LoadDevices(GeographicAddress address) {
            if (address is null) return;
            var id = address.Data?.ID ?? string.Empty;
            var devices = await dbSet.Include(x => x.Device).Where(x => x.AddressID == id)
                .AsNoTracking().ToListAsync();
            foreach (var c in devices)
                address.RegisteredTelecomDevice(new TelecomAddress(c.Device));
        }
        public async Task<TelecomDeviceRegistration> GetObject(string adr, string dev) {
            var r = await dbSet.AsNoTracking()
                .SingleOrDefaultAsync(x => x.AddressID == adr && x.DeviceID == dev);
            return createObject(r);
        }
        protected internal override TelecomDeviceRegistration createObject(
            TelecomDeviceRegistrationData r) {
            return new TelecomDeviceRegistration(r);
        }
        protected internal override async Task<TelecomDeviceRegistrationData> getObject(
            string id) {
            return await dbSet.AsNoTracking()
                .SingleOrDefaultAsync(x => x.AddressID == id || x.DeviceID == id);
        }
    }
}




