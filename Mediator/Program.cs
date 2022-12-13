using System;

namespace Mediator
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConcreteMediator m = new ConcreteMediator();

            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);

            m.Colleague1 = c1;
            m.Colleague2 = c2;

            c1.Send("How are you");
            c2.Send("Fine, thanks");

            Console.ReadKey();
        }
    }

    public abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleauge);
    }

    public class ConcreteMediator : Mediator
    {
        ConcreteColleague1 colleague1;
        ConcreteColleague2 colleague2;

        public ConcreteColleague1 Colleague1 {  set { colleague1 = value; } }
        public ConcreteColleague2 Colleague2 { set { colleague2 = value; } }
        public override void Send(string message, Colleague colleauge)
        {
            if (colleauge == colleague1) colleague2.Notify(message);
            else colleague1.Notify(message);
        }
    }

    public abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    public class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message) => mediator.Send(message, this);
        public void Notify(string message) => Console.WriteLine("Colleauge1 gets message: " + message);
    }

    public class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator)
            : base(mediator)
        {
        }

        public void Send(string message) => mediator.Send(message, this);
        public void Notify(string message) => Console.WriteLine("Colleauge2 gets message: " + message);
    }
    

}
