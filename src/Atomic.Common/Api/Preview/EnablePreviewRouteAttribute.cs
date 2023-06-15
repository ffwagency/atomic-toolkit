namespace Atomic.Common.Api.Preview
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class EnablePreviewRouteAttribute : Attribute
    { }
}