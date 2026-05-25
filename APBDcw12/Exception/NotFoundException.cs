namespace APBDcw12.Exception;

public class NotFoundException : System.Exception
{
    public NotFoundException()
    {
    }

    public NotFoundException(string? message) : base(message)
    {
    }
}