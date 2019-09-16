namespace p_hello_xamarin.Services
{
    public class _c_helloserv : _i_helloserv
    {
        public double f_tip_(double subTotal, int generosity)
        {
            return subTotal * generosity / 100.0;
        }
    }
}