using Topshelf;

namespace TS.API
{
    class Program
    {
        private static int Main()
        {
            var exitCode = HostFactory.Run(host =>
            {
                host.Service<SampleService>(service =>
                {
                    service.ConstructUsing(() => new SampleService());
                    service.WhenStarted(a => a.Start());
                    service.WhenStopped(a => a.Stop());
                });

                host.RunAsNetworkService();
            });
            return (int)exitCode;
        }
    }
}
