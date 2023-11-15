using Travel_Agency_Core;
using Travel_Agency_DataBase;
using Travel_Agency_Domain.Payments;

namespace Travel_Agency_Logic.Offers
{
    public abstract class ReserveTicketService : ReserveService<ReserveTicket, PaymentTicket>
    {
        protected ReserveTicketService(TravelAgencyContext context) : base(context)
        {
        }

        internal override bool CheckPermissions(UserBasic user)
            => user.Role == Roles.EmployeeAgency;
    }
}