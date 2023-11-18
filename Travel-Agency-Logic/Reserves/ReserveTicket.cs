using Travel_Agency_Core;
using Travel_Agency_DataBase;
using Travel_Agency_Domain.Payments;

namespace Travel_Agency_Logic.Offers
{
    public class ReserveTicketService : ReserveService<ReserveTicket, PaymentTicket>
    {
        public ReserveTicketService(TravelAgencyContext context) : base(context)
        {
        }

        internal override bool CheckPermissions(UserBasic user)
            => user.Role == Roles.EmployeeAgency;
    }
}