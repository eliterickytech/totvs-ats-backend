using Flunt.Notifications;

namespace Totvs.ATS.Shared
{
    public abstract class BaseContractString : Notifiable<Notification>
    {

        protected abstract void Validate(string entity);
    }
}
