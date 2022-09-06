namespace WebApiEntregas.Models
{
    public class Delivery
    {

        public Delivery(int id, string numeroDaEntrega, DateTime dataDaEntrega)
        {
            Id = id;
            NumeroDaEntrega = numeroDaEntrega;
            DataDaEntrega = dataDaEntrega;
        }


        public void SetDeliveryNumber(string deliveryNumber)
        {
            this.NumeroDaEntrega = deliveryNumber;
        }

        public void SetDeliveryData(DateTime deliveryData)
        {
            this.DataDaEntrega = deliveryData;
        }


        public int Id { get; private set; }
        public string NumeroDaEntrega { get; private set; }
        public DateTime DataDaEntrega { get; private set; }
        
    }
}
