class Program
{
    static void Main(string[] args)
    {
        IDevice device = (new Product() as IProduct).GetDevice();

        // C# 8.0 이전 컴파일 오류
        // C# 9.0 + .NET 5 환경에서 컴파일 가능
        /*
        ISoundDevice soundDevice = new Headset().GetDevice();
        */

        // C# 8.0 이전
        // C# 9.0 + .NET Core 3.1 이하
        IDevice hds = new Headset().GetDevice();
    }
}

public interface IProduct
{
    IDevice GetDevice();
}

public class Product : IProduct
{
    public virtual IDevice GetDevice() { return new Device(); }
}

public class Headset : Product
{
    // C# 8.0 이전 컴파일 오류
    // C# 9.0 + .NET 5 환경에서 컴파일 가능
    /*
    public override ISoundDevice GetDevice()
    {
        return new SoundDevice();
    }
    */

    // C# 8.0 이전
    // C# 9.0 + .NET Core 3.1 이하
    public override IDevice GetDevice()
    {
        return new SoundDevice();
    }
}

public interface IDevice
{
}

public class Device : IDevice
{
}

public interface ISoundDevice : IDevice
{
}

public class SoundDevice : ISoundDevice
{
}