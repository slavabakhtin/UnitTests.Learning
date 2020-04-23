namespace LogAnalyzer
{
    public class ExtensionManagerFactory
    {
        private static IExtensionManager _manager;

        public bool IsValidLogFileName(string fileName)
        {
            return this.IsValid(fileName);
        }

        public virtual bool IsValid(string fileName)
        {
            FileExtensionManager fileExtensionManager = new FileExtensionManager();
            return fileExtensionManager.IsValid(fileName);
        }
    }
}
