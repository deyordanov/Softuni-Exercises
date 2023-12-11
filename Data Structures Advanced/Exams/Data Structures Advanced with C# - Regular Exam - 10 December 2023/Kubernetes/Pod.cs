namespace Kubernetes
{
    public class Pod
    {
        public string Id { get; set; }

        public string ServiceName { get; set; }

        public int Port { get; set; }

        public string Namespace { get; set; }
    }
}