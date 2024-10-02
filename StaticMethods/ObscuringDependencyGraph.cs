using NUnit.Framework;
using Moq;

[TestFixture]
public class BankAccountTests
{
    [Test]
    public void TransferTo_ShallRemoveAmountFromOneAccount_AndAddItToAnother()
    {
        var bankAccount1 = new BankAccount(
            new Mock<ITransferServiceManager>().Object);
        bankAccount1.AddFunds(1000);

        var bankAccount2 = new BankAccount(
            new Mock<ITransferServiceManager>().Object);
        bankAccount1.TransferTo(bankAccount2, 200);

        Assert.That(bankAccount1.Balance, Is.EqualTo(800));
        Assert.That(bankAccount2.Balance, Is.EqualTo(200));
    }
}

class BankAccount
{
    private ITransferServiceManager _transferServiceManager;

    public BankAccount(ITransferServiceManager transferServiceManager)
    {
        _transferServiceManager = transferServiceManager;
    }

    public int Balance { get; private set; }

    public void AddFunds(int amount)
    {
        // imagine a lot of complicated code
        throw new NotImplementedException();
    }

    public void TransferTo(BankAccount other, int amount)
    {
        // imagine a lot of complicated code
        throw new NotImplementedException();
    }
}


public interface ITransferServiceManager
{

}

public interface IInternalServiceQueue
{

}

class TransferServiceManager : ITransferServiceManager
{
    private IInternalServiceQueue _internalServiceQueue;

    public TransferServiceManager(IInternalServiceQueue internalServiceQueue)
    {
        _internalServiceQueue = internalServiceQueue;
    }
}

class InternalServiceQueue : IInternalServiceQueue
{
}