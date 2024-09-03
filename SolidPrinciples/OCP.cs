//var videosRepository = new VideosRepository();
//var user = new User(new FreeAccount(videosRepository));
//Console.WriteLine("Videos this user can see: " +
//    string.Join(", ", user.GetAvailableVideos()));

//var youngUser = new User(new KidsAccount(videosRepository));

//var availableVideos = youngUser.GetAvailableVideos();

//Console.WriteLine("Videos this young user can see: " +
//    string.Join(", ", availableVideos));


//AccountType accountType = AccountType.Free; //value chosen by the user

//var newUser = new User(new AccountsFactory().CreateAccount(accountType));
//Console.ReadKey();

public class AccountsFactory
{
    public IAccount CreateAccount(AccountType accountType)
    {
        var videosRepository = new VideosRepository();

        switch (accountType)
        {
            case AccountType.Free:
                return new FreeAccount(videosRepository);
            case AccountType.Kids:
                return new KidsAccount(videosRepository);
            case AccountType.Premium:
                return new PremiumAccount(videosRepository);
        }

        throw new NotSupportedException("Invalid account type");
    }
}

public class User
{
    private IAccount _account;

    public User(IAccount account)
    {
        _account = account;
    }

    public List<Video> GetAvailableVideos()
    {
        return _account.GetAvailableVideos();
    }
}

public interface IAccount
{
    AccountType AccountType { get; }
    List<Video> GetAvailableVideos();
}

public class KidsAccount : IAccount
{
    public AccountType AccountType { get; } = AccountType.Kids;
    private IVideosRepository _videosRepository;

    public KidsAccount(IVideosRepository videosRepository)
    {
        _videosRepository = videosRepository;
    }

    public List<Video> GetAvailableVideos()
    {
        return _videosRepository
            .GetAll()
            .Where(video => video.IsForKids)
            .ToList();
    }
}

public class FreeAccount : IAccount
{
    public AccountType AccountType { get; } = AccountType.Free;
    private IVideosRepository _videosRepository;

    public FreeAccount(IVideosRepository videosRepository)
    {
        _videosRepository = videosRepository;
    }

    public List<Video> GetAvailableVideos()
    {
        return _videosRepository
            .GetAll()
            .Where(video => video.IsFree)
            .ToList();
    }
}

public class PremiumAccount : IAccount
{
    public AccountType AccountType { get; } = AccountType.Premium;
    private IVideosRepository _videosRepository;

    public PremiumAccount(IVideosRepository videosRepository)
    {
        _videosRepository = videosRepository;
    }

    public List<Video> GetAvailableVideos()
    {
        return _videosRepository
            .GetAll();
    }
}

public enum AccountType
{
    Free,
    Premium,
    Kids
}

public class Video
{
    public bool IsForKids { get; init; }
    public bool IsFree { get; init; }
    public string Title { get; init; }

    public override string ToString() => Title;
}

public interface IVideosRepository
{
    List<Video> GetAll();
    List<Video> GetAll(string region);
}

public class VideosRepository : IVideosRepository
{
    public List<Video> GetAll()
    {
        return new List<Video>
        { 
            new Video { IsFree = true, Title = "City Lights" },
            new Video { IsFree = false, Title = "The Kid" },
        };
    }

    public List<Video> GetAll(string region)
    {
        throw new NotImplementedException();
    }
}