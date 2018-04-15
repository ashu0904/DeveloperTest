using Autofac;


namespace FileData
{
    using ThirdPartyTools;
    using ThirdPartyTools.Interface;

    public static class ContainerConfig
    {
        private static IContainer Container { get; set; }

        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();

            builder.RegisterType<FileDetails>().As<IFileDetails>();

            return builder.Build();

        }
    }
}
