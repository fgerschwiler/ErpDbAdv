using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBW.BPFM.DBAdv.ErpClient.Utilities
{
    public class Fragment
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Fragment(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public static Fragment FromString(string f)
        {
            if (string.IsNullOrWhiteSpace(f))
                return null;

            var pair = f.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
            if (pair.Length != 2 || string.IsNullOrWhiteSpace(pair[1]))
                return null;

            return new Fragment(pair[0], pair[1]);
        }
    }
}
