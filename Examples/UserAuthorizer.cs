using System.Runtime.Serialization;
using System.Text.RegularExpressions;

public class UserAuthorizer
{
    private readonly IUserRepository _usersRepository;
    private readonly IPermissionsRepository _permissionsRepository;

    public UserAuthorizer(
        IUserRepository usersRepository,
        IPermissionsRepository permissionsRepository)
    {
        _usersRepository = usersRepository;
        _permissionsRepository = permissionsRepository;
    }

    public AuthorizationResult Authorize(User user, UserAction action)
    {
        if (!_usersRepository.DoesExist(user))
        {
            throw new NonExistentUserException(user);
        }

        if (user.IsSuperUser || IsUserAuthorizedToPerform(action, user))
        {
            return AuthorizationResult.Authorized;
        }
        return AuthorizationResult.NotAuthorized;
    }

    private bool IsUserAuthorizedToPerform(UserAction action, User user)
    {
        return _permissionsRepository
            .GetForUser(user.Id)
            .Any(permission => permission.Action == action);
    }

    public AuthorizationResult Auth(User u, UserAction ua)
    {
        if (_usersRepository.GetById(u.Id) == null)
        {
                throw new NonExistentUserException(u);
            }

        var perm = _permissionsRepository.GetForUser(u.Id);

        if(u.IsSuperUser)
        {
            return AuthorizationResult.Authorized;
        }

        foreach(var p in perm)
        {
            if(p.Action == ua) {
                return AuthorizationResult.Authorized;
            }
        }
        return AuthorizationResult.NotAuthorized;
    }
}

public enum AuthorizationResult
{
    Authorized,
    NotAuthorized
}

public enum UserAction { }

public struct User
{
    public bool IsSuperUser { get; internal set; }
    public object Id { get; internal set; }
}

public interface IUserRepository
{
    bool DoesExist(User user);
    object GetById(object id);
}

public interface IPermissionsRepository
{
    IEnumerable<UserPermission> GetForUser(object id);
    bool IsUserAuthorizedToPerform(UserAction action, User user);
}

public struct UserPermission
{
    public UserAction Action { get; internal set; }
}

[Serializable]
internal class NonExistentUserException : Exception
{
    private User user;

    public NonExistentUserException()
    {
    }

    public NonExistentUserException(User user)
    {
        this.user = user;
    }

    public NonExistentUserException(string? message) : base(message)
    {
    }

    public NonExistentUserException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected NonExistentUserException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

public static class OrderPriceCalculator
{
    public static decimal CalculateTotalPrice(
        int quantity, decimal unitPrice, decimal tax)
    {
        return quantity * unitPrice * (1 + tax);
    }
}

public class OrderPriceCalculatorBad
{
    private decimal _tax;

    public OrderPriceCalculatorBad(decimal tax)
    {
        _tax = tax;
    }

    public decimal CalculateTotalPrice(
        int quantity, decimal unitPrice)
    {
        return quantity * unitPrice * (1 + _tax);
    }
}
 