using Autobots.Entities.Context;
using Autobots.Entities.DataAccess.Repositories;
using Autobots.Entities.Models.DB;

namespace Autobots.Entities.DataAccess
{
    public class DbService : IDbService
    {
        private readonly ApplicationDbContext _context;
        private Repository<CarMake> _CarMakes;
        private Repository<CarModel> _CarModels;
        private Repository<Order> _Orders;
        private Repository<OrderDetail> _OrderDetails;
        private Repository<PriceChart> _PriceCharts;
        private Repository<Service> _Services;
        private Repository<SubService> _SubServices;
        private Repository<TimingSlot> _TimingSlots;
        private Repository<Subscribers> _Subscribers;
        private Repository<CallNumbers> _Callnumbers;
        private Repository<Booking> _Booking;
        private Repository<Complaint> _Complaints;
        private Repository<Car> _Car;
        private Repository<OrderServiceCharge> _OrderServiceCharge;

        public DbService()
        {
            _context = new ApplicationDbContext();
        }

        public Repository<CarMake> CarMakes => _CarMakes ?? (_CarMakes = new CarMakeRepository(_context));

        public Repository<CarModel> CarModels => _CarModels ?? (_CarModels = new CarModelRepository(_context));

        public Repository<Order> Orders => _Orders ?? (_Orders = new OrderRepository(_context));

        public Repository<OrderDetail> OrderDetails => _OrderDetails ?? (_OrderDetails = new OrderDetailRepository(_context));

        public Repository<PriceChart> PriceCharts => _PriceCharts ?? (_PriceCharts = new PriceChartRepository(_context));

        public Repository<Service> Services => _Services ?? (_Services = new ServiceRepository(_context));

        public Repository<SubService> SubServices => _SubServices ?? (_SubServices = new SubServiceRepository(_context));

        public Repository<TimingSlot> TimingSlots => _TimingSlots ?? (_TimingSlots = new TimingSlotRepository(_context));

        public Repository<Subscribers> Subscribers => _Subscribers ?? (_Subscribers = new SubscriberRepository(_context));
        public Repository<CallNumbers> CallNumbers => _Callnumbers ?? (_Callnumbers = new CallMeRepository(_context));
        public Repository<Booking> Booking => _Booking ?? (_Booking = new BookingRepository(_context));
        public Repository<Complaint> Complaint => _Complaints ?? (_Complaints = new ComplaintRepository(_context));
        public Repository<Car> Car => _Car ?? (_Car = new UserCarRepository(_context));
        public Repository<OrderServiceCharge> OrderServiceCharge => _OrderServiceCharge ?? (_OrderServiceCharge = new OrderServiceChargeRepository(_context));
    }
}