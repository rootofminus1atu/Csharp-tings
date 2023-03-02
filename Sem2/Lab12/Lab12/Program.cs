namespace Lab12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // how tf do I add decorators to C#
            var main = new ConcreteComponent();
            var decoratorA = new ConcreteDecoratorA(main);
            var decoratorB = new ConcreteDecoratorB(main);

            decoratorB.Operation();
        }
    }

    interface IComponent
    {
        void Operation();
    }

    class ConcreteComponent : IComponent
    {
        public void Operation()
        {
            Console.WriteLine("ConcreteComponent operation");
        }
    }

    abstract class Decorator : IComponent
    {
        protected IComponent component;

        public Decorator(IComponent component)
        {
            this.component = component;
        }

        public virtual void Operation()
        {
            component.Operation();
        }
    }

    class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(IComponent component) : base(component)
        {
        }

        public override void Operation()
        {
            AddedBehavior();
            base.Operation();
        }

        private void AddedBehavior()
        {
            Console.WriteLine("ConcreteDecoratorA AddedBehavior");
        }
    }

    class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(IComponent component) : base(component)
        {
        }

        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
        }

        private void AddedBehavior()
        {
            Console.WriteLine("ConcreteDecoratorB AddedBehavior");
        }
    }
}