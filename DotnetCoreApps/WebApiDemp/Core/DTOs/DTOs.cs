namespace BookAuthorApi.Core.DTOs
{
    //record types for data transfer objects (DTOs). They internally represent simplified versions of the Author and Book entities.
    public record AuthorDto(int AuthorId, string Name);
    public record BookDto(int BookId, string Title, double BookPrice, int AuthorId);
}