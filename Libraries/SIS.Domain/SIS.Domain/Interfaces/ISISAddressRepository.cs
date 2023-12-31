namespace SIS.Domain.Interfaces
{
    public interface ISISAddressRepository
    {
        public Dictionary<string, Address> Addresses { get; }

        public Dictionary<string, Address> RefreshAddresses();
        public bool Exists(Address address);
        public void Insert(Address address);
        public void Update(Address address);
        public void Delete(Address address);
    }
}