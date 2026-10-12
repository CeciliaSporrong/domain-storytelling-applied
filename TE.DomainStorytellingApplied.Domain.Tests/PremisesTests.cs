using TE.DomainStorytellingApplied.Domain;

namespace TE.DomainStorytellingApplied.Domain.Tests;

public class PremisesTests
{
    [Fact]
    public void GivenValidDetails_WhenCreating_ShouldKeepDetails()
    {
        var premisesId = Id.Generate();
        string[] equipment = ["Projector", "Whiteboard"];

        var premises = new Premises(
            premisesId,
            "Conference Room",
            "Main Street 1",
            12,
            equipment);

        premises.PremisesId.ShouldBe(premisesId);
        premises.Name.ShouldBe("Conference Room");
        premises.Address.ShouldBe("Main Street 1");
        premises.Capacity.ShouldBe(12);
        premises.Equipment.ShouldBe(equipment);
    }

    [Fact]
    public void GivenEmptyName_WhenCreating_ShouldThrow()
    {
        Should.Throw<ArgumentException>(() =>
            new Premises(Id.Generate(), "", "Main Street 1", 12, []));
    }

    [Fact]
    public void GivenEmptyAddress_WhenCreating_ShouldThrow()
    {
        Should.Throw<ArgumentException>(() =>
            new Premises(Id.Generate(), "Conference Room", "", 12, []));
    }

    [Fact]
    public void GivenInvalidCapacity_WhenCreating_ShouldThrow()
    {
        Should.Throw<ArgumentOutOfRangeException>(() =>
            new Premises(Id.Generate(), "Conference Room", "Main Street 1", 0, []));
    }
}