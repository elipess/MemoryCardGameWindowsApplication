namespace MemoryGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                FormUserInterface ui = new FormUserInterface();
                ui.Run();
            }
            catch (System.Exception)
            {
                return;
            } 
        }
    }
}