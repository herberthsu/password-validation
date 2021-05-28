using System.Linq;
using PasswordValidation.Specifications.Interfaces;

namespace PasswordValidation.Specifications.Implementation
{
    public class NotFollowBySameSequenceOfCharacters : INotFollowBySameSequenceOfCharacters
    {
        public bool IsSatisfiedBy(string entity)
        {
            var dictionary = entity
                .ToCharArray()
                .Select((c, i) => new {i, c})
                .ToLookup(x => x.c, x => x.i)
                .Where(x => x.Count() > 1);

            foreach (var elem in dictionary)
            {
                var indexes = elem.ToArray();

                for (int i = 0; i < indexes.Length - 1; i++)
                {
                    var index = indexes[i];
                    var nextIndex = indexes[i + 1];

                    var containsSequence = true;
                    var j = 0;

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