namespace ShittyDesmos;

public static class Extensions
{
    public static bool TryFirst<T>(this IEnumerable<T> collection, Func<T, bool> condition, out T result)
    {
        // double enumeration but im too lazy to optimize
        
        result = default;

        if (!collection.Any(condition)) 
            return false;
        
        result = collection.First(condition);
        return true;
    }
}