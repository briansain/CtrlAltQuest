using Akka.Actor;
using Akka.DependencyInjection;
using System.Reflection;

namespace CtrlAltQuest.Common.Actors
{
    public class ActorManager<TActor> : ReceiveActor
    {
        private static Func<CharacterId, IDependencyResolver, Props>? MethodInfo;
        public ActorManager()
        {
            if (MethodInfo == null)
            {
                MethodInfo = (Func<CharacterId, IDependencyResolver, Props>)Delegate.CreateDelegate(typeof(Func<CharacterId, IDependencyResolver,Props>), typeof(TActor).GetMethod("PropsFor")!);
            }
            
            Receive<ICharacterMessage>(msg =>
            {
                var child = Context.Child(msg.CharacterId.ToString());
                if (child.IsNobody())
                {
                    child = Context.ActorOf(MethodInfo!.Invoke(msg.CharacterId, DependencyResolver.For(Context.System).Resolver), msg.CharacterId.ToString());
                    Context.Watch(child);
                }
                child.Forward(msg);
            });
        }
    }
}
