using System.Linq;
using PasswordValidation.Specifications.Interfaces;

namespace PasswordValidation.Specifications.Implementation
{
    public class NotFollowBySameSequenceOfCharacters : INotFollowBySameSequenceOfCharacters
    {
        public bool IsSatisfiedBy(string entity)
        {
            /*
            1. converting string to array of characters 
            2. group the characters and store its indexes 
            3. filter it by number of stored index is more than 1
            
            sample string passpass
            IGrouping<char, int>
                [0] Key = p
                    [0] = 0
                    [1] = 4
                [1] Key = a
                    [0] = 1
                    [1] = 5
                [2] Key = s
                    [0] = 2
                    [1] = 3
                    [2] = 6
                    [3] = 7
            */
            var dictionary = entity
                .ToCharArray()
                .Select((c, i) => new {i, c})
                .ToLookup(x => x.c, x => x.i)
                .Where(x => x.Count() > 1);

            // this loop is getting the character and its indexes
            foreach (var elem in dictionary)
            {
                var indexes = elem.ToArray();

                // this loop is getting the list of indexes
                for (int i = 0; i < indexes.Length - 1; i++)
                {
                    var index = indexes[i];
                    var nextIndex = indexes[i + 1];

                    var containsSequence = true;
                    var j = 0;

                    /*
                    if the 2 characters are right next to each other,
                    it doesn't considered as containing sequence
                    */
                    if (nextIndex - (index + j) == 1)
                    {
                        continue;
                    }
                    
                    while (index + j != nextIndex)
                    {
                        if (nextIndex + j >= entity.Length)
                        {
                            containsSequence = false;
                            break;
                        } 
                        
                        if (entity[index + j] != entity[nextIndex + j])
                        {
                            containsSequence = false;
                            break;
                        }

                        j += 1;
                    }

                    if (containsSequence)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}