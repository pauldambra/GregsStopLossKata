namespace GregsStopLoss
{
    interface IHandle<in T>
    {
        void Handle(T command);
    }
}