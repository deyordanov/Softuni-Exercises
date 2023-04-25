using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public class Robot : IRobot
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model
        {
            get => this.model;
            private set => this.model = value;
        }
        public string Id
        {
            get => this.id;
            private set => this.id = value;
        }
    }
}
