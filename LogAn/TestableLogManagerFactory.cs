﻿using LogAnalyzer;

namespace LogAn
{
    public class TestableLogManagerFactory : ExtensionManagerFactory
    {
        private readonly IExtensionManager _manager;

        public TestableLogManagerFactory(IExtensionManager manager)
        {
            _manager = manager;
        }
    }
}
