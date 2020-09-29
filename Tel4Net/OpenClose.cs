namespace Tel4Net
{
    internal class OpenClose
    {
        public OpenClose(char opening, char closing)
        {
            Opening = opening;
            Closing = closing;
        }

        public char Opening { get; private set; }
        public char Closing { get; private set; }
    }
}