//#####################################################
//LSP - Violating base type interface - before refactoring

//Plane plane = new ToyPlane();

//var remainingFuel = plane.PercentOfRemainingFuel();
//Console.WriteLine(remainingFuel);

//Console.ReadKey();

public abstract class Plane
{
    public virtual int MaxFuel => 1000;
    public virtual int RemainingFuel => 1000;

    public float PercentOfRemainingFuel()
    {
        return ((float)RemainingFuel / MaxFuel) * 100;
    }

    public abstract string Land();
}

public class CargoPlane : Plane
{
    public override int MaxFuel => 2000;
    public override int RemainingFuel => 2000;

    public override string Land()
    {
        return "Land on the airstrip near the cargo terminal";
    }
}

public class ToyPlane : Plane
{
    public override int MaxFuel => 0;
    public override int RemainingFuel => 0;

    public override string Land()
    {
        return "Just don't hit the floor too hard.";
    }
}

//#####################################################
//LSP - Violating base type interface - after refactoring

//IFuelable fuelable = new CargoPlane();

//var fuelCalculator = new FuelCalculator();
//var remainingFuel = fuelCalculator.GetPercentOfRemainingFuel(fuelable);
//Console.WriteLine(remainingFuel);
//Console.ReadKey();

//public interface IFuelable
//{
//    int MaxFuel { get; }
//    int RemainingFuel { get; }
//}

//public abstract class Plane
//{
//    public abstract string Land();
//}

//public class CargoPlane : Plane, IFuelable
//{
//    public int MaxFuel => 2000;
//    public int RemainingFuel => 2000;

//    public override string Land()
//    {
//        return "Land on the airstrip near the cargo terminal";
//    }
//}

//public class AreobaticPlane : Plane, IFuelable
//{
//    public int MaxFuel => 200;
//    public int RemainingFuel => 200;

//    public override string Land()
//    {
//        return "Land in fashion.";
//    }
//}

//public class FuelCalculator
//{
//    public float GetPercentOfRemainingFuel(IFuelable fuelable)
//    {
//        return ((float)fuelable.RemainingFuel / fuelable.MaxFuel) * 100;
//    }
//}

//public class ToyPlane : Plane
//{
//    public override string Land()
//    {
//        return "Just don't hit the floor too hard.";
//    }
//}






////#####################################################
////LSP - Runtime Type Switching - before refactoring

//void FuelAll(List<IFuelable> fuelables, FuelHose hose)
//{
//    foreach (var fuelable in fuelables)
//    {
//        if (fuelable is KeroseneLamp)
//        {
//            var lamp = fuelable as KeroseneLamp;
//            var adapter = new HoseAdapter(lamp);
//            adapter.Attach(hose);
//        }
//        else
//        {
//            fuelable.Attach(hose);
//        }

//        hose.Fuel(fuelable);
//    }
//}

public interface IFuelable
{
    int MaxFuel { get; }
    int RemainingFuel { get; }

    void Attach(FuelHose hose);
}

public class FuelHose
{
    public void Fuel(IFuelable fuelable)
    {
        //fuel the fuelable
    }
}

public class KeroseneLamp : IFuelable
{
    public int MaxFuel => 3;
    public int RemainingFuel => 3;

    public void Attach(FuelHose hose)
    {
        throw new InvalidOperationException(
            "Can't attach fuel hose");
    }
}

public class HoseAdapter
{
    private KeroseneLamp _lamp;

    public HoseAdapter(KeroseneLamp? lamp)
    {
        _lamp = lamp;
    }

    public void Attach(FuelHose hose)
    {
        //attach hose to the adapter
    }
}

////#####################################################
////LSP - Runtime Type Switching - refactor 1 (KeroseneLamp is fuelable)

//void FuelAll(List<IFuelable> fuelables, FuelHose hose)
//{
//    foreach (var fuelable in fuelables)
//    {
//        fuelable.Attach(hose);
//        hose.Fuel(fuelable);
//    }
//}


//public interface IFuelable
//{
//    int MaxFuel { get; }
//    int RemainingFuel { get; }

//    void Attach(FuelHose hose);
//}

//public class FuelHose
//{
//    public void Fuel(IFuelable fuelable)
//    {
//        //fuel the fuelable
//    }
//}

//public class KeroseneLamp : IFuelable
//{
//    public int MaxFuel => 3;
//    public int RemainingFuel => 3;

//    public void Attach(FuelHose hose)
//    {
//        var adapter = new HoseAdapter(this);
//        adapter.Attach(hose);
//    }
//}

//public class HoseAdapter
//{
//    private KeroseneLamp _lamp;

//    public HoseAdapter(KeroseneLamp? lamp)
//    {
//        _lamp = lamp;
//    }

//    public void Attach(FuelHose hose)
//    {
//        //attach hose to the adapter
//    }
//}

////#####################################################
////LSP - Runtime Type Switching - refactor 2 (KeroseneLamp is not fuelable)

//void FuelAll(List<IFuelable> fuelables, FuelHose hose)
//{
//    foreach (var fuelable in fuelables)
//    {
//        fuelable.Attach(hose);
//        hose.Fuel(fuelable);
//    }
//}

//public interface IFuelContainer
//{
//    int MaxFuel { get; }
//    int RemainingFuel { get; }
//}

//public interface IFuelable : IFuelContainer
//{
//    void Attach(FuelHose hose);
//}

//public class FuelHose
//{
//    public void Fuel(IFuelable fuelable)
//    {
//        //fuel the fuelable
//    }
//}

//public class KeroseneLamp : IFuelContainer
//{
//    public int MaxFuel => 3;
//    public int RemainingFuel => 3;
//}




////#####################################################
////LSP - Runtime Type Switching - before refactor

public class BankAccount
{
    public virtual void Withdraw(int amount)
    {
        if (amount < 10000)
        {
            Console.WriteLine($"Withdrawing amount:{amount}");
            //perform withdrawal
        }
        else
        {
            Console.WriteLine(
                $"Withdrawing {amount} requires extra authorization");
            //do not perform withdrawal
        }
    }
}

public class ChildrenAccount : BankAccount
{
    public override void Withdraw(int amount)
    {
        if (amount < 1000)
        {
            Console.WriteLine($"Withdrawing amount:{amount}");
            //perform withdrawal
        }
        else
        {
            Console.WriteLine(
                $"Withdrawing {amount} requires extra authorization");
            //do not perform withdrawal
        }
    }
}

////#####################################################
////LSP - Runtime Type Switching - after refactor

//public enum BankAccountType
//{
//    Adults,
//    Children
//}

//public class BankAccount
//{
//    private int _maxWithdrawalWithoutExtraAuthorization;

//    private BankAccount(int maxWithdrawalWithoutExtraAuthorization)
//    {
//        _maxWithdrawalWithoutExtraAuthorization = maxWithdrawalWithoutExtraAuthorization;
//    }

//    public static BankAccount Create(BankAccountType type)
//    {
//        switch (type)
//        {
//            case BankAccountType.Adults:
//                return new BankAccount(10000);
//            case BankAccountType.Children:
//                return new BankAccount(1000);
//        }
//        throw new NotSupportedException("Unsupported account type.");
//    }

//    public virtual void Withdraw(int amount)
//    {
//        if (amount < _maxWithdrawalWithoutExtraAuthorization)
//        {
//            Console.WriteLine($"Withdrawing amount:{amount}");
//            //perform withdrawal
//        }
//        else
//        {
//            Console.WriteLine(
//                $"Withdrawing {amount} requires extra authorization");
//            //do not perform withdrawal
//        }
//    }
//}


