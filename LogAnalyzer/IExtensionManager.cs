using System;
using System.Collections.Generic;
using System.Text;

namespace LogAnalyzer
{
    public interface IExtensionManager
    {
        bool IsValid(string fileName);
    }
}
