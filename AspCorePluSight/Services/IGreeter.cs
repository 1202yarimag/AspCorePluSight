namespace AspCorePluSight.Services
{
    public interface IGreeter
    {
        string GetMessage();
    }
    public class Greeter:IGreeter
    {

        public string GetMessage()
        {

            return "Hello Igreeter Interface";
        }

      

    }
}