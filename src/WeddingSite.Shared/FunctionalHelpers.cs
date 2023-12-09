using LanguageExt.Common;

namespace WeddingSite.Shared;

public static class FunctionalHelpers
{
    public static Result<TB> Bind<TA, TB>(this Result<TA> wrappedValue, Func<TA, Result<TB>> f)
    {
        if (wrappedValue.IsFaulted)
        {
            Exception ex = new BottomException();
            wrappedValue.IfFail(e => ex = e);

            return new Result<TB>(ex);
        }

        Result<TB> result = default;
        wrappedValue.IfSucc(value => result = f(value));

        return result;
    }

    public static Result<TB> Bind<TA, TB>(this Result<TA> wrappedValue, Func<TA, TB> f)
    {
        if (wrappedValue.IsFaulted)
        {
            Exception ex = new BottomException();
            wrappedValue.IfFail(e => ex = e);

            return new Result<TB>(ex);
        }

        try
        {
            TB? result = default;
            wrappedValue.IfSucc(value => result = f(value));

            return result switch
            {
                null => new Result<TB>(new Exception("The result of f was null during a bind operation.")),
                _ => new Result<TB>(result)
            };
        }
        catch (Exception e)
        {
            return new Result<TB>(e);
        }
    }
}