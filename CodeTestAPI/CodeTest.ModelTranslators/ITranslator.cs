using System.Collections.Generic;

namespace CodeTest.ModelTranslators
{
    /// <summary>
    /// This interface Provides the abstraction for 
    /// 1 Model and DTO mapping.
    /// 2.Refineing DTO data(remove duplicates objects etc.) 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TC"></typeparam>
    public interface ITranslator<T,TC>
    {
        IList<TC> Translate(IEnumerable<T> input);
        IList<TC> Validate(IEnumerable<T> input);
    }
}