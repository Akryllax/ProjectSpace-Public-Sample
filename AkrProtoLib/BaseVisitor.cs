namespace NetworkCore
{
    public abstract class BaseVisitor
    {
        public abstract void VisitTransaction(BaseTransaction transaction);
    }
}
