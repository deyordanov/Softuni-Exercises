using System.Collections.Generic;

namespace Kubernetes
{
    public interface IController
    {
        void Deploy(Pod pod);

        bool Contains(string podId);

        int Size();

        Pod GetPod(string podId);

        void Uninstall(string podId);

        void Upgrade(Pod pod);

        IEnumerable<Pod> GetPodsInNamespace(string @namespace);

        IEnumerable<Pod> GetPodsBetweenPort(int lowerBound, int upperBound);

        IEnumerable<Pod> GetPodsOrderedByPortThenByName();
    }
}