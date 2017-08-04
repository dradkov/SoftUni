namespace _03BarracksFactory.Attribute
{
    using System;


    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class InjectAttribute : Attribute
    {
    }
}
