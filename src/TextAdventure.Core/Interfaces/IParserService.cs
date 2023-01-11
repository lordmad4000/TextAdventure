namespace TextAdventure.Core.Interfaces
{
    public interface IParserService
    {
        ITextAdventureAction ParseTextInputCommand(string textInputCommand);
    }
}