using DBAccess;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelWebApplication.Models
{
    public partial class CustomerModel
    {
        public int ID { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start time")]
        public DateTime? startTime { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("End time")]
        public DateTime? endTime { get; set; }

        public int? resID { get; set; }

        public IEnumerable<HotelRoom>? rooms { get; set; }

        public Customer customer { get; set; }
        public ReservationTable reservation { get; set; }

        public CustomerModel()
        {

        }
    }
}
