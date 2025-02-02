using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using System.Security.Cryptography;
using OpenEugene.Module.LittleHelpBook.Models;

namespace OpenEugene.Module.LittleHelpBook.Repository
{
    public partial class LittleHelpBookRepository
    {

        public List<Address> GetAddressesByProviderId(int providerId, bool tracking = false) {
            // get a list of addresses for a provider
            var addrs = from a in _db.Address
                        where a.ProviderId == providerId
                        select a;
            return addrs.ToList();
        }

        public Address GetAddressByAddressId(int addressId) {
            return GetAddress(addressId, true);
        }

        public Address GetAddress(int addressId, bool tracking) {
            return tracking ? _db.Address.Find(addressId) : _db.Address.AsNoTracking().FirstOrDefault(item => item.AddressId == addressId);
        }

        public Address AddAddress(Address item) {
            _db.Address.Add(item);
            _db.SaveChanges();
            return item;
        }

        public Address UpdateAddress(Address addressId) {
            _db.Entry(addressId).State = EntityState.Modified;
            _db.SaveChanges();
            return addressId;
        }

        public void DeleteAddress(int addressId) {
            var item = _db.Address.Find(addressId);

            if (item == null) return;
            _db.Address.Remove(item);
            _db.SaveChanges();
        }
    }
}