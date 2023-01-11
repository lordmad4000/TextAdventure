namespace TextAdventure.Core.Models
{
    public class Phrase
    {
        public Phrase(string verb, string parameter1, string parameter2, string parameter3)
        {
            Verb = verb;
            Parameter1 = parameter1;
            Parameter2 = parameter2;
            Parameter3 = parameter3;
        }

        public string Verb { get; set; }
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }
        public string Parameter3 { get; set; }

    }
}
