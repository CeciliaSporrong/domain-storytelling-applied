using TE.DomainStorytellingApplied.Domain;

namespace TE.DomainStorytellingApplied.Domain.Tests;

public class BookerTests
{
    [Fact]
    public void GivenValidDetails_WhenCreating_ShouldKeepDetails()
    {
        var bookerId = Id.Generate();
        var booker = new Booker(bookerId, "Anna Andersson");

        booker.BookerId.ShouldBe(bookerId);
        booker.Name.ShouldBe("Anna Andersson");
    }

    [Fact]
    public void GivenEmptyName_WhenCreating_ShouldThrow()
    {
        Should.Throw<ArgumentException>(() =>
            new Booker(Id.Generate(), ""));
    }
}