namespace TextAdventure.Core.Models
{
    public class CommandResult
    {
        public CommandResult(string textInput, string textOutput, Adventure adventure)
        {
            TextInput = textInput;
            TextOutput = textOutput;
            Adventure = adventure;
        }

        public string TextInput { get; set; }
        public string TextOutput { get; set; }
        public Adventure Adventure { get; set; }
    }
}
