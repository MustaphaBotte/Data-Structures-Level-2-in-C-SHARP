using System.Collections;
namespace ISet
{
    internal class Program
    {
        public interface ISet<T> : ICollection<T>, IEnumerable<T>, IEnumerable
        {
            // Add : Adds an element to the set, returns false if it already exists.
            bool Add(T item);

            // ExceptWith : Removes all elements found in 'other' from the current set.
            void ExceptWith(IEnumerable<T> other);

            // IntersectWith : Keeps only elements that exist in both the current set and 'other'.
            void IntersectWith(IEnumerable<T> other);

            // IsProperSubsetOf : Returns true if current set is strictly smaller than and contained in 'other'.
            bool IsProperSubsetOf(IEnumerable<T> other);

            // IsProperSupersetOf : Returns true if current set strictly contains all elements of 'other' and more.
            bool IsProperSupersetOf(IEnumerable<T> other);

            // IsSubsetOf : Returns true if every element in current set exists in 'other'.
            bool IsSubsetOf(IEnumerable<T> other);

            // IsSupersetOf : Returns true if current set contains every element in 'other'.
            bool IsSupersetOf(IEnumerable<T> other);

            // Overlaps : Returns true if current set and 'other' share at least one common element.
            bool Overlaps(IEnumerable<T> other);

            // SetEquals : Returns true if current set and 'other' contain exactly the same elements.
            bool SetEquals(IEnumerable<T> other);

            // SymmetricExceptWith : Keeps only elements that exist in one set but not both.
            void SymmetricExceptWith(IEnumerable<T> other);

            // UnionWith : Adds all elements from 'other' into the current set, ignoring duplicates.
            void UnionWith(IEnumerable<T> other);
        }
        static void Main(string[] args)
        {
           // ISet Interface 
           // i will not implement the entire interface like i did before in IDictionary
           // you will find the method that you need to implement with a description
           // in case you want to create your own ISet

        }
    }
}
