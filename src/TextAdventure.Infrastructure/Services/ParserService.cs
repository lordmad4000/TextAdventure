using System.Text.RegularExpressions;
using TextAdventure.Core.Actions;
using TextAdventure.Core.Interfaces;
using TextAdventure.Core.Models;
using TextAdventure.Infrastructure.ActionVerbs;

namespace TextAdventure.Infrastructure.Services
{
    public class ParserService : IParserService
    {
        private List<string> NotValidWords = new List<string>() { "at", "to", "the", "on", "in", "from", "about", "me", "with", "for" };
        private List<string> JoinWords = new List<string>() { "turn on", "turn off" };
        public ITextAdventureAction ParseTextInputCommand(string textInputCommand)
        {
            ITextAdventureAction action = new CantDoAction();
            textInputCommand = Clean(textInputCommand);
            List<string> inputCommand = ConvertToList(textInputCommand);
            var phrase = ConvertToPhrase(textInputCommand);
            //action = CheckActions(inputCommand);
            action = CheckActions(phrase);

            return action;
        }
        private string Clean(string textInputCommand)
        {
            textInputCommand = textInputCommand.Trim()
                                               .ToLower();
            textInputCommand = RemoveConsecutiveSpaces(textInputCommand);
            textInputCommand = JoiningWords(textInputCommand);
            textInputCommand = RemoveNotValidWords(textInputCommand);

            return textInputCommand;
        }

        private string JoiningWords(string textInputCommand)
        {
            foreach (var word in JoinWords)
            {
                textInputCommand = textInputCommand.Replace(word, word.Replace(" ", ""));
            }

            return textInputCommand;
        }

        private string RemoveNotValidWords(string textInputCommand)
        {
            string pattern = $@"\b{string.Join(@"\b|\b", NotValidWords)}\b";
            textInputCommand = Regex.Replace(textInputCommand, pattern, string.Empty);
            textInputCommand = RemoveConsecutiveSpaces(textInputCommand);
            return textInputCommand;
        }

        private string RemoveConsecutiveSpaces(string textInputCommand)
        {
            string pattern = "[ ]{2,}";
            textInputCommand = Regex.Replace(textInputCommand, pattern, " ");

            return textInputCommand;
        }

        private List<string> ConvertToList(string textInputCommand)
        {
            return textInputCommand.Split(' ', '.', ',')
                                   .ToList();
        }

        private Phrase ConvertToPhrase(string textInputCommand)
        {
            var splitCommand = textInputCommand.Split(' ', '.', ',');
            string verb = splitCommand.Length > 0 ? splitCommand[0] : "";
            string parameter1 = splitCommand.Length > 1 ? splitCommand[1] : "";
            string parameter2 = splitCommand.Length > 2 ? splitCommand[2] : "";
            string parameter3 = splitCommand.Length > 3 ? splitCommand[3] : "";
            var phrase = new Phrase(verb, parameter1, parameter2, parameter3);

            return phrase;
        }

        private ITextAdventureAction CheckActions(Phrase phrase)
        {
            ITextAdventureAction action = new CantDoAction();
            var actionVerbs = new List<IActionVerb>();
            actionVerbs.Add(new GoActionVerb());
            actionVerbs.Add(new ExitsActionVerb());
            actionVerbs.Add(new AskActionVerb());
            var verb = actionVerbs.FirstOrDefault(x => x.Check(phrase) is not CantDoAction);

            if (verb != null)
            {
                return verb.Check(phrase);
            }

            return action;
        }
    }

}
