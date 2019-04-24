using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteArtists.Helpers
{
    public static class Validations
    {
        public static bool NotNull(params string[] inputs)
        {
            bool notNull = true;
            foreach (string input in inputs)
            {
                if (input == null)
                {
                    notNull = false;
                    break;
                }
            }
            return notNull;
        }
    }
}
