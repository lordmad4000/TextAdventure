using TextAdventure.Infrastructure.ActionVerbs;
using TextAdventure.Core.Models;
using TextAdventure.Core.Actions;

namespace TextAdventure.Infrastructure.Tests.UnitTests;

public class ExitsActionVerbTest
{
    [Fact]
    public void Should_Be_ExitsAction_When_Verb_Phrase_Is_Exits()
    {
        // Arrange
        var actionVerb = new ExitsActionVerb();

        // Act
        var textAdventureAction = actionVerb.Check(new Phrase("Exits","","",""));

        //Assert
        Assert.IsType<ExitsAction>(textAdventureAction);
    }

    [Fact]
    public void Should_Be_CanDoAction_When_Verb_Phrase_Is_Empty()
    {
        // Arrange
        var actionVerb = new ExitsActionVerb();

        // Act
        var textAdventureAction = actionVerb.Check(new Phrase("","","",""));

        //Assert
        Assert.IsType<CantDoAction>(textAdventureAction);
    }

    [Fact]
    public void Should_Be_CanDoAction_When_Verb_Phrase_Is_Go()
    {
        // Arrange
        var actionVerb = new ExitsActionVerb();

        // Act
        var textAdventureAction = actionVerb.Check(new Phrase("Go","","",""));

        //Assert
        Assert.IsType<CantDoAction>(textAdventureAction);
    }
}