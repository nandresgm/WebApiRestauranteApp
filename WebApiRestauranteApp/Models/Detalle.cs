namespace WebApiRestauranteApp.Models
{
    public class Detalle
    {
        public int Id { get; set; }
        public int Pedido { get; set; }
        public int Menu { get; set; }
        public int Cantidad { get; set; }
        public int SubTotal { get; set; }
        public int ValorVenta { get; set; }
        public int Venta { get; set; }
        public int Total { get; }
    }
}
