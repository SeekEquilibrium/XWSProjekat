namespace Post.Service
{
    public class Dtos
    {
        public record UsersPostDto(Guid UserId, Guid PostId, string text);
        public record PostDto(Guid PostId, string Text, DateTimeOffset PostDate);
    }
}