namespace MIBI.UnitTests
{
    public class TestsInitializer
    {
        private static bool testInitialized = false;

        public void Initialize()
        {
            if (!testInitialized)
            {
                // TO DO: Initializing of Automaper and other logik here!

                testInitialized = true;
            }
        }
    }
}
