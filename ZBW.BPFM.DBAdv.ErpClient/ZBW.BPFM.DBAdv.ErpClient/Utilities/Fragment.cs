using System;
using System.Collections.Generic;

namespace ZBW.BPFM.DBAdv.ErpClient.Utilities
{
    public class Fragment : Dictionary<string, string>
    {

        public static Fragment FromString(string f)
        {
            if (string.IsNullOrWhiteSpace(f))
                return null;

            var pairs = f.Split(new[] { "&", "=" }, StringSplitOptions.RemoveEmptyEntries);

            if (pairs.Length % 2 > 0)
                throw new InvalidOperationException("fragment must have key and values");

            var dict = new Fragment();

            for (int i = 0; i < pairs.Length; i++)
            {
                dict[pairs[i]] = pairs[i + 1];
                i++;
            }

            return dict;
        }
    }
}
