namespace SpiceJetElementsInteractionTests1
{
    internal class Order
    {
        public Order()
        {
        }

        public object OrderId { get; set; }
        public object Item { get; set; }
        public object Quantity { get; set; }

        internal void Dump()
        {
            throw new NotImplementedException();
        }
    }
}