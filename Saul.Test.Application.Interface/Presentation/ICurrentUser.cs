namespace Saul.Test.Application.Interface.Presentation
{
    public interface ICurrentUser
    {
        string? UserId { get; }
        string? UserName { get; }
    }
}
