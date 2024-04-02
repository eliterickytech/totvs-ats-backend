using Flunt.Notifications;

namespace Totvs.ATS.Shared
{
    public abstract class BaseContract<Entity> : Notifiable<Notification> where Entity : class
    {
        protected abstract void Validate(Entity entity);
    }
}
