using TextAdventure.Infrastructure.ActionVerbs;
using TextAdventure.Core.Models;
using TextAdventure.Core.Actions;

namespace TextAdventure.Infrastructure.Tests.UnitTests;

public class GoActionVerbTest
{
    [Fact]
    public void Should_Be_GoAction_When_Verb_Phrase_Is_Go_And_Parameter1_IsValid_Direction()
    {
        // Arrange
        var actionVerb = new GoActionVerb();

        // Act
        var textAdventureAction = actionVerb.Check(new Phrase("Go","Northwest","",""));

        //Assert
        var goAction = Assert.IsType<GoAction>(textAdventureAction);
    }

    [Fact]
    public void Should_Be_GoAction_When_Verb_Phrase_Is_Move_And_Parameter1_IsValid_Direction()
    {
        // Arrange
        var actionVerb = new GoActionVerb();

        // Act
        var textAdventureAction = actionVerb.Check(new Phrase("Move","Northwest","",""));

        //Assert
        var goAction = Assert.IsType<GoAction>(textAdventureAction);
    }

    [Theory]
    [InlineData("Go", "Northwest", Directions.Northwest)]
    [InlineData("Go", "North", Directions.North)]
    [InlineData("Go", "Northeast", Directions.Northeast)]
    [InlineData("Go", "West", Directions.West)]
    [InlineData("Go", "East", Directions.East)]
    [InlineData("Go", "Southwest", Directions.Southwest)]
    [InlineData("Go", "South", Directions.South)]
    [InlineData("Go", "Southeast", Directions.Southeast)]
    [InlineData("Go", "Up", Directions.Up)]
    [InlineData("Go", "Down", Directions.Down)]
    [InlineData("Go", "Inside", Directions.Inside)]
    [InlineData("Go", "Outside", Directions.Outside)]
    public void Should_Be_GoAction_With_Expected_Direction(string verb, string parameter1, Directions expectedDirection)
    {
        // Arrange
        var actionVerb = new GoActionVerb();

        // Act
        var textAdventureAction = actionVerb.Check(new Phrase(verb, parameter1, "", ""));

        //Assert
        var goAction = Assert.IsType<GoAction>(textAdventureAction);
        Assert.Equal(goAction.Direction, expectedDirection);
    }

    [Theory]
    [InlineData("", "Northwest")]
    [InlineData("Go", "")]
    [InlineData("moving", "Northeast")]
    public void Should_Be_CanDoAction(string verb, string parameter1)
    {
        // Arrange
        var actionVerb = new GoActionVerb();

        // Act
        var textAdventureAction = actionVerb.Check(new Phrase(verb, parameter1, "", ""));

        //Assert
        var goAction = Assert.IsType<CantDoAction>(textAdventureAction);
    }

}