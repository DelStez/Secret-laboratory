using System.Collections.Generic;

namespace MutatorProject
{
    internal class CodeFile
    {
        public string fn;
        public string text;

        public CodeFile(string fn, string text)
        {
            this.fn = fn;
            this.text = text;
        }
    }
}